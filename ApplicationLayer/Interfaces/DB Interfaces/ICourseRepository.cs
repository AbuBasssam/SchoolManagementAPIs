using ApplicationLayer.Features.Courses.Queries.GetCoursesFilterPage;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Entities;

public interface ICourseRepository : IStaticGenericRepository<Course>, ICommanCourseValidation, IAddCourseValidation
{
    //IQueryable<Course> GetByCode(string CourseCode);
    IQueryable<Course> GetByName(string CourseName);
    Task<bool> IsExistsByCodeAsync(string CourseCode);
    //Task<bool> IsExistsByNameAsync(string CourseName);
    Task<PagedCourseResult> GetCoursesFilter(CourseFilter filter, FilterInfo filterInfo);
    Task<bool> IsPrerequisiteAlreadyExistsAsync(string CourseCode);
}
