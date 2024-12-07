using ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment;
using ApplicationLayer.Features.Enrollment.Queries.GetAvailableEnrollmentCourses;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IEnrollmentServices
    {
        Task<IList<AvailableEnrollmentCoursesDTO>> GeAvailableEnrollmentCourses(string StudentNumber);
        Task<bool> AddNewEnrollmentAsync(AddNewEnrollmentCommandDTO DTO);
        Task<bool> AnySectionScheduleConflict(string StudentNumber, string SectionNumber);
        IQueryable<Enrollment> GetEnrollment(string StudentNumber, string SectionNumber);
        Task<bool> DeleteAsync(Enrollment enrollment);

    }
}
