using ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment;
using ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses;
using ApplicationLayer.Interfaces;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Exceptoins.Enrollment;
using DomainLayer.Exceptoins.Schedule;
using DomainLayer.Exceptoins.Section;
using DomainLayer.Exceptoins.Student;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class EnrollmentService : IEnrollmentServices
    {
        private readonly IEnrollmentRepository _repo;
        private readonly IMapper _mapper;
        ISectionRepository _sectionRepository;
        IStudentRepository _studentRepository;

        public EnrollmentService(IEnrollmentRepository repo, IMapper mapper, IStudentRepository studentRepository, ISectionRepository sectionRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<bool> AddNewEnrollmentAsync(AddNewEnrollmentCommandDTO DTO)
        {
            // 1) is Section and Student number Exists
            var Student = await _CheckStudentExists(DTO.StudentNumber);

            var Section = await _CheckSectionExists(DTO.SectionNumber);

            //2) is Already enrolled or pass section course
            await _IsAlreadyPassed(DTO.StudentNumber, Section.Course.CourseCode);

            await _IsAlreadyEnrolled(DTO.StudentNumber, Section.Course.CourseCode);



            //3) Any Conflict with other enrolled section
            if (await AnySectionScheduleConflict(DTO.StudentNumber, DTO.SectionNumber))
                throw new ScheduleConflictException($"Student with number {DTO.StudentNumber} enrolled in another section with same time");

            //4) Map the DTO to Enrollment object
            var enrollment = new Enrollment
            {
                EnrollmentDate = DateTime.Now,
                SectionID = Section!.Id,
                StudentID = Student!.Id,
                IsStudentPass = null,


            };
            // 5) Add the  Enrollment object and return result
            return await _repo.AddAsync(enrollment) != 0;
        }
        public async Task<bool> AnySectionScheduleConflict(string StudentNumber, string SectionNumber)
            => await _repo.AnySectionScheduleConflict(StudentNumber, SectionNumber);



        public Task<IList<AvailableEnrollmentCoursesDTO>> GeAvailableEnrollmentCourses(string StudentNumber)
            => _repo.GeAvailableEnrollmentCourses(StudentNumber);

        #region Abstraction
        private async Task<Student> _CheckStudentExists(string StudentNumber)
        {
            var Student = await _studentRepository.GetByStudentNumber(StudentNumber).AsNoTracking().FirstOrDefaultAsync();//.Include(s=>s.UserInfo)

            return (Student != null) ? Student : throw new StudentNotExistsException(StudentNumber);
        }
        private async Task<Section> _CheckSectionExists(string SectionNumber)
        {
            var Section = await _sectionRepository.GetByNumber(SectionNumber).Include(s => s.Course).AsNoTracking().FirstOrDefaultAsync();
            return (Section != null) ? Section : throw new SectionNotExistsException(SectionNumber);
        }

        private async Task _IsAlreadyEnrolled(string StudentNumber, string CourseCode)
        {
            if (await _repo.IsAlreadyEnrolled(StudentNumber, CourseCode))
                throw new DuplicateEnrollmentException(StudentNumber, CourseCode);



        }
        private async Task _IsAlreadyPassed(string StudentNumber, string courseCode)
        {
            if (await _repo.IsAlreadyPassed(StudentNumber, courseCode))
                throw new EnrollmentPassedCourseException(StudentNumber, courseCode);

        }

        public IQueryable<Enrollment> GetEnrollment(string StudentNumber, string SectionNumber)
            => _repo.GetEnrollment(StudentNumber, SectionNumber);

        public Task<bool> DeleteAsync(Enrollment enrollment)
            => _repo.DeleteAsync(enrollment);





        #endregion
    }
}