using ApplicationLayer.Interfaces;
using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public class AttendanceService : IAttendanceService
    {
        public Task<bool> AddAsync(Attendance entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(ICollection<Attendance> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Attendance> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Attendance entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRange(ICollection<Attendance> entities)
        {
            throw new NotImplementedException();
        }
    }
}