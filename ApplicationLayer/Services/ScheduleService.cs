using ApplicationLayer.Features.Schedule.Queries.GetAvailableSchedules;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using DomainLayer.Entities;
using DomainLayer.Exceptoins.Class;
using DomainLayer.Helper_Classes;

namespace ApplicationLayer.Services
{
    public class ScheduleService : IScheduleService
    {
        #region Field(s)
        private readonly IScheduleRepository _repo;
        private readonly IClassRepository _classRepository;

        #endregion

        #region Constructure(S)
        public ScheduleService(IScheduleRepository repo, IClassRepository classRepository)
        {
            _repo = repo;
            _classRepository = classRepository;
        }

        #endregion

        #region Action Method(s)
        public async Task<bool> AddAsync(Schedule entity) => await _repo.AddAsync(entity) != 0;

        public async Task<bool> AddRangeAsync(ICollection<Schedule> entities) => await _repo.AddRangeAsync(entities);




        public async Task<ICollection<WeekSchedule>> GetAvailableSchedules(GetAvailableSchedulesQueryDTO DTO)
        {
            if (!await _classRepository.IsExistsByName(DTO.ClassName))
                throw new ClassNotExistsException(DTO.ClassName);

            return await _repo.GetAvailableSchedules(DTO);
        }

        public IQueryable<Schedule> GetById(int Id)
            => _repo.GetById(Id);

        public IQueryable<Schedule> GetBySectionID(int SectionID) => _repo.GetById(SectionID);

        public IQueryable<Schedule> GetBySectionNumber(string SectionNumber)
        {
            throw new NotImplementedException();
        }


        public Task<PaginatingResult> GetPaginateInfo() => _repo.GetPaginateInfo();

        public IQueryable<Schedule> GetSchedulesPage(int pageNumber)
            => _repo.GetPage(pageNumber);



        public async Task<bool> UpdateAsync(Schedule entity)
            => await _repo.UpdateAsync(entity);

        public async Task<bool> UpdateRange(ICollection<Schedule> entities)
        => await _repo.UpdateRangeAsync(entities);
        #endregion
    }
}