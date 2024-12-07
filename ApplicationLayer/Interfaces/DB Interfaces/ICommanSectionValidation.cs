using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public interface ICommanSectionValidation 
    {
        Task<bool> CheckSectionScheduleConflict(Schedule Schedule);



    }
}
