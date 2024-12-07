using DomainLayer.Entities;

namespace ApplicationLayer.Models
{
    public class PagedCourseResult
    {
        public List<Course> Courses { get; set; } = null!;
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}