using ApplicationLayer.Features.Courses;
using ApplicationLayer.Features.Courses.Commands;
using ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage;
using ApplicationLayer.Models;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface ICourseService
    {
        #region Action Method(s)
        IQueryable<Course> GetById(int id);

        IQueryable<Course> GetByName(string CourseName);

        IQueryable<Course> GetCoursesPage(int PageNumber = 1);

        IQueryable<Course> GetByCode(string CourseCode);

        Task<bool> IsExistsByCodeAsync(string CourseCode);

        Task<bool> IsExistsByNameAsync(string CourseName);

        Task<PagedCourseResult> GetCoursesFilterPage(CourseFilter filter, FilterInfo filterInfo);

        Task<bool> AddAsync(AddCourseCommandDTO entity);

        Task<bool> UpdateAsync(string CourseCode, UpdateCourseCommandDTO entity);

        Task<bool> AddRangeAsync(ICollection<AddCourseCommandDTO> entities);

        Task<PaginatingResult> GetPaginateInfo();

        Task<bool> ChangePrerequisiteCourse(PrerequisiteCourseCommandDTO dto);

        Task<bool> AddPrerequisiteCourse(PrerequisiteCourseCommandDTO dto);

        //Task<bool> UpdateRange(ICollection<AddCourseCommandDTO> entities);


        #endregion

    }
}
