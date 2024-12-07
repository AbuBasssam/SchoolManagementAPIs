using ApplicationLayer.Features.Schedule.Queries;
using ApplicationLayer.Features.SectionFeature.Commands;
using ApplicationLayer.Features.SectionFeature.Commands.UpdateSection;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.Exceptoins.Class;
using DomainLayer.Exceptoins.Course;
using DomainLayer.Exceptoins.Schedule;
using DomainLayer.Exceptoins.Section;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class SectionService : ISectionService
    {
        #region Fields

        private readonly ISectionRepository _repo;
        private readonly IClassValidation _classValidation;
        private readonly ICommanCourseValidation _courseValidation;
        private readonly ITeacherExistsService _teacherExistsService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructure(s)

        public SectionService(ISectionRepository SectionRepository, IClassValidation classValidation, IMapper mapper,
                              ICommanCourseValidation courseValidation, ITeacherExistsService teacherExistsService)
        {
            _repo = SectionRepository;

            _classValidation = classValidation;

            _mapper = mapper;

            _courseValidation = courseValidation;

            _teacherExistsService = teacherExistsService;
        }

        #endregion

        #region Action Methods

        public IQueryable<Section> GetByNumber(string SectionName)
            => _repo.GetByNumber(SectionName);

        public IQueryable<Section> GetById(int id)
            => _repo.GetById(id);

        public async Task<bool> IsExistsByIdAsync(int ID)
            => await _repo.IsExistsByIdAsync(ID);

        public async Task<bool> IsExistsByNumberAsync(string SectionName)
            => await _repo.IsExistsByNumberAsync(SectionName);

        public async Task<bool> AddAsync(AddSectionCommandDTO entity)
        {
            await _IsSectionUnique(entity.SectionNumber);

            var course = await _CheckCourseExists(entity.CourseCode);

            var ScheduleClass = await _CheckClassExists(entity.Schedule.ClassName);

            // Validation logic: Practical section can only be added to courses that allow practicals.
            _ValidateSectionType(course, entity.SectionType);

            await _AnyScheduleConflict(entity.Schedule);

            using (var transaction = _repo.BeginTransaction())
            {
                try
                {
                    var section = _mapper.Map<Section>(entity);

                    await _AddSection(course.Id, ScheduleClass.Id, section);

                    transaction.Commit();

                    return true;
                }
                catch
                {

                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAsync(Section entity)
            => await _repo.UpdateAsync(entity);

        public async Task<bool> AddRangeAsync(ICollection<Section> entities)
            => await _repo.AddRangeAsync(entities);

        public async Task<bool> UpdateRangeAsync(ICollection<Section> entities)
            => await _repo.UpdateRangeAsync(entities);

        public async Task<bool> CloseAsync(string SectionNumber)
        {
            // Ensure the Section is exists
            await _IsSectionExists(SectionNumber);

            return await _repo.CloseAsync(SectionNumber);
        }

        public IQueryable<Section> GetSectionsPage(int pageNumber = 1)
            => _repo.GetPage(pageNumber);

        public async Task<PaginatingResult> GetPaginateInfo()
            => await _repo.GetPaginateInfo();

        public async Task<bool> CheckSectionScheduleConflict(Schedule Schedule)
            => await _repo.CheckSectionScheduleConflict(Schedule);

        public async Task<bool> UpdateSectionSchedule(UpdateSectionCommandDTO DTO)
        {
            await _IsSectionExists(DTO.SectionNumber);

            var ScheduleClass = await _CheckClassExists(DTO.Schedule.ClassName);

            await _AnyScheduleConflict(DTO.Schedule);

            var oldSchedule = await GetSectionSchedule(DTO.SectionNumber).AsNoTracking().FirstAsync();

            return await _UpdateSectionSchedule(DTO.SectionNumber, oldSchedule, DTO.Schedule, ScheduleClass.Id);

        }

        public IQueryable<Schedule> GetSectionSchedule(string SectionNumber)
            => _repo.GetSectionSchedule(SectionNumber);

        public async Task<bool> AssignSectionTeacher(string SectionNumber, string TeacherNumber)
        {
            var Section = await _CheckSectionExists(SectionNumber);

            var Teacher = await _CheckTeacherExists(TeacherNumber);
            var conflicts = await _repo.CheckTeacherSchedulConflict(TeacherNumber, Section.Schedule);

            if (conflicts.Count > 0)
            {
                throw new ScheduleConflictException("there is a conflict with " + string.Join("\n", conflicts));
            }


            return await _repo.AssignSectionTeacher(SectionNumber, Teacher.Id);
        }

        #endregion

        #region Abstraction
        private async Task _AddSection(int courseId, int ClassID, Section section)
        {


            section.Schedule.Class = null!; //null;

            section.Schedule.ClassID = ClassID;

            section.Course = null!;// null;

            section.CourseID = courseId;

            section.IsOpen = true;

            await _repo.AddAsync(section);

        }

        private async Task<bool> _UpdateSectionSchedule(string SectionNumber, Schedule OldSchedule, ScheduleDTO NewSchedule, int ClassID)
        {
            _mapper.Map(NewSchedule, OldSchedule);

            OldSchedule.Class = null!;// null;

            OldSchedule.ClassID = ClassID;

            return await _repo.UpdateSectionSchedule(SectionNumber, OldSchedule);
        }

        private void _ValidateSectionType(Course course, enType SectionType)
        {
            if (!(course.HasPractical || SectionType == enType.Theory))
                throw new NotAcceptSectionTypeException(course.CourseCode);
        }

        private async Task _AnyScheduleConflict(ScheduleDTO entity)
        {
            var schedule = _mapper.Map<Schedule>(entity);

            if (await _repo.CheckSectionScheduleConflict(schedule))
                throw new ScheduleConflictException("there is a schedule conflict");
        }

        private async Task _IsSectionUnique(string SectionNumber)
        {
            if (await _repo.IsExistsByNumberAsync(SectionNumber))
                throw new DuplicateSectionNumberException(SectionNumber);
        }

        private async Task _IsSectionExists(string SectionNumber)
        {
            if (!await _repo.IsExistsByNumberAsync(SectionNumber))
                throw new SectionNotExistsException(SectionNumber);
        }

        private async Task<Course> _CheckCourseExists(string CourseCode)
        {
            var course = await _courseValidation.GetByCode(CourseCode).AsNoTracking().FirstOrDefaultAsync();

            return (course is not null) ? course : throw new NotExistsByCourseCodeException(CourseCode);


        }

        private async Task<Class> _CheckClassExists(string ClassName)
        {
            var Class = await _classValidation.GetByName(ClassName).AsNoTracking().FirstOrDefaultAsync();

            return (Class is not null) ? Class : throw new ClassNotExistsException(ClassName);


        }

        private async Task<Section> _CheckSectionExists(string SectionNumber)
        {
            var Section = await _repo.GetByNumber(SectionNumber).Include(s => s.Schedule).ThenInclude(sch => sch.Class).AsNoTracking().FirstOrDefaultAsync();

            return Section is not null ? Section : throw new SectionNotExistsException(SectionNumber);
        }

        private async Task<Teacher> _CheckTeacherExists(string TeacherNumber)
        {
            var teacher = await _teacherExistsService.GetByUserName(TeacherNumber).AsNoTracking().FirstOrDefaultAsync();
            return teacher is not null ? teacher : throw new TeacherNotExistsException(TeacherNumber);
        }



        #endregion

    }

}
