using ApplicationLayer.Features.Courses;
using ApplicationLayer.Features.Courses.Commands;
using ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Exceptoins.Course;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class CourseService : ICourseService
    {
        #region Fields

        private readonly ICourseRepository _repo;
        private readonly IMapper _Mapper;

        #endregion

        #region Constructure(s)
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _repo = courseRepository;
            _Mapper = mapper;

        }
        #endregion

        #region Action Methods
        public IQueryable<Course> GetByCode(string CourseCode)
            => _repo.GetByCode(CourseCode);

        public IQueryable<Course> GetById(int id)
            => _repo.GetById(id);

        public IQueryable<Course> GetByName(string CourseName)
             => _repo.GetByName(CourseName);

        public IQueryable<Course> GetCoursesPage(int PageNumber = 1)
             => _repo.GetPage(PageNumber);

        public async Task<bool> IsExistsByCodeAsync(string CourseCode)
            => await _repo.IsExistsByCodeAsync(CourseCode);

        public async Task<bool> IsExistsByNameAsync(string CourseName)
            => await _repo.IsExistsByNameAsync(CourseName);

        public async Task<bool> AddAsync(AddCourseCommandDTO entity)
        {
            // Validate the incoming course entity to ensure it meets all required criteria.
            await _AddValidation(entity);

            //Add the course and return result
            return await _AddNewCourse(entity);

        }

        public async Task<bool> UpdateAsync(string CourseCode, UpdateCourseCommandDTO entity)
        {
            // Validate the incoming course code exist.
            var course = await _CodeExistsValidation(CourseCode);


            // Map the DTO (Data Transfer Object) to the Course entity
            _Mapper.Map(entity, course);


            // Update the course  and return result
            return await _repo.UpdateAsync(course);

        }

        public async Task<bool> AddRangeAsync(ICollection<AddCourseCommandDTO> entities)
        {
            List<Course> courses = new List<Course>();

            foreach (var entity in entities)
            {
                await _AddValidation(entity);
                courses.Add(_Mapper.Map<Course>(entity));
            }

            return await _repo.AddRangeAsync(courses);

        }

        public async Task<PagedCourseResult> GetCoursesFilterPage(CourseFilter filter, FilterInfo filterInfo)
            => await _repo.GetCoursesFilter(filter, filterInfo);

        public async Task<bool> AddPrerequisiteCourse(PrerequisiteCourseCommandDTO dto)
        {
            // Validate if the main course exists using the provided course code

            var course = await _CodeExistsValidation(dto.CourseCode);
            // Validate if the prerequisite course exists using the provided prerequisite course code

            var PrerequisiteCourse = await _PrerequisiteCourseValidation(dto.PrerequisiteCourseCode);

            // Check if the specified course is already set as a prerequisite for another course

            await _IsAlreadyPrerequisite(dto.PrerequisiteCourseCode);


            // Add Prerequisite course info
            course.HasPrerequisite = true;

            course.PrerequisiteCourse = PrerequisiteCourse;

            course.PrerequisiteID = PrerequisiteCourse.Id;

            // Update the course in the repository and return the result of the operation

            return await _repo.UpdateAsync(course);

        }

        public async Task<bool> ChangePrerequisiteCourse(PrerequisiteCourseCommandDTO dto)
        {
            // Validate if the main course exists using the provided course code

            var course = await _CodeExistsValidation(dto.CourseCode);

            // Validate if the prerequisite course exists using the provided prerequisite course code

            var PrerequisiteCourse = await _PrerequisiteCourseValidation(dto.PrerequisiteCourseCode);

            // Validate if the main course Has Prerequisite
            _IsHasPrerequisite(course);


            // Check if the specified course is already set as a prerequisite for another course
            await _IsAlreadyPrerequisite(dto.PrerequisiteCourseCode);

            // update Prerequisite course info
            course.PrerequisiteCourse = PrerequisiteCourse;

            course.PrerequisiteID = PrerequisiteCourse.Id;

            return await _repo.UpdateAsync(course);
        }

        public async Task<PaginatingResult> GetPaginateInfo()
            => await _repo.GetPaginateInfo();

        #endregion

        #region Abstraction

        private async Task _AddValidation(AddCourseCommandDTO entity)
        {
            await _DuplicateCourseCodeValidation(entity.CourseCode);

            await _DuplicateCourseNameValidation(entity.CourseName);

        }

        private async Task<bool> _AddNewCourse(AddCourseCommandDTO entity)
        {
            return !string.IsNullOrWhiteSpace(entity.PrerequisiteCourseCode) ?
                 await _AddCourseWithPrerequisite(entity) : await _AddCourseWithoutPrerequisite(entity);
        }

        private async Task<Course> _PrerequisiteCourseValidation(string PrerequisiteCourseCode)
        {
            var course = await _repo.GetByCode(PrerequisiteCourseCode).FirstOrDefaultAsync();

            return (course is null) ? throw new PrerequisiteNotExistsException(PrerequisiteCourseCode) : course;
        }

        private async Task _DuplicateCourseNameValidation(string CourseName)
        {
            if (await _repo.IsExistsByNameAsync(CourseName))
                throw new DuplicateCourseNameException(CourseName);
        }

        private async Task _DuplicateCourseCodeValidation(string CourseCode)
        {
            if (await _repo.IsExistsByCodeAsync(CourseCode))
                throw new DuplicateCourseCodeException(CourseCode);
        }

        private async Task<Course> _CodeExistsValidation(string CourseCode)
        {
            var course = await _repo.GetByCode(CourseCode).FirstOrDefaultAsync();

            return (course is null) ? throw new NotExistsByCourseCodeException(CourseCode) : course;
        }

        private async Task<bool> _AddCourseWithoutPrerequisite(AddCourseCommandDTO entity)
        {
            // Map the DTO (Data Transfer Object) to the Course entity.
            var course = _Mapper.Map<Course>(entity);

            //Add the course and return result

            return await _repo.AddAsync(course) != 0;

        }

        private async Task<bool> _AddCourseWithPrerequisite(AddCourseCommandDTO entity)
        {
            Course course;
            var prerequisteCourse = await _PrerequisiteCourseValidation(entity.PrerequisiteCourseCode!);

            // Map the DTO (Data Transfer Object) to the Course entity.
            course = _Mapper.Map<Course>(entity);


            // Add prerequiste Course info
            course.PrerequisiteCourse = prerequisteCourse;

            course.PrerequisiteID = prerequisteCourse.Id;


            //Add the course and return result
            return await _repo.AddAsync(course) != 0;
        }

        private void _IsHasPrerequisite(Course course)
        {
            if (!course.HasPrerequisite)
                throw new PrerequisiteNullableExceptoin(course.CourseCode);

        }

        private async Task _IsAlreadyPrerequisite(string courseCode)
        {
            if (await _repo.IsPrerequisiteAlreadyExistsAsync(courseCode))
                throw new DuplicatePrerequisiteExceptoin(courseCode);

        }
        #endregion
    }

}
