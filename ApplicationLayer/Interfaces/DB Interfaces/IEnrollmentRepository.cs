using ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses;
using ApplicationLayer.Interfaces;
using DomainLayer.Entities;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
    Task<IList<AvailableEnrollmentCoursesDTO>> GeAvailableEnrollmentCourses(string StudentNumber);
    Task<bool> IsAlreadyEnrolled(string StudentNumber, string courseCode);
    Task<bool> IsAlreadyPassed(string StudentNumber, string courseCode);
    Task<bool> AnySectionScheduleConflict(string StudentNumber, string SectionNumber);
    IQueryable<Enrollment> GetEnrollment(string StudentNumber, string SectionNumber);
}