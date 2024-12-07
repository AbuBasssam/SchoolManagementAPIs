using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface ICommanCourseValidation
    {
        IQueryable<Course> GetByCode(string CourseCode);

    }
}
