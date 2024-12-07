using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces
{
    public interface IAttendanceService
    {
        #region Action Method(s)
        IQueryable<Attendance> GetById(int id);
        Task<bool> AddAsync(Attendance entity);
        Task<bool> UpdateAsync(Attendance entity);
        Task<bool> AddRangeAsync(ICollection<Attendance> entities);
        Task<bool> UpdateRange(ICollection<Attendance> entities);

        #endregion
    }
}
