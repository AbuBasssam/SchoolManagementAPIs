using ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.DB_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Exceptoins.Employment_Details;
using DomainLayer.Exceptoins.Teacher;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class EmploymentDetailsService : IEmploymentDetailsService
    {
        #region Field(s)
        private readonly IEmploymentDetailsRepository _repo;
        private readonly IMapper _mapper;
        private readonly IsExistsTeacherSrevice _IExistsTeacherSrevice;
        #endregion

        #region Constructure(s)

        public EmploymentDetailsService(IEmploymentDetailsRepository repository, IMapper mapper, IsExistsTeacherSrevice isExistsTeacherSrevice)
        {
            _repo = repository;
            _mapper = mapper;
            _IExistsTeacherSrevice = isExistsTeacherSrevice;
        }

        #endregion

        #region Action(s)
        public IQueryable<EmploymentDetail> GetById(int id) => _repo.GetById(id);


        public IQueryable<EmploymentDetail> GetByTeacherNumber(string TeacherNumber) => _repo.GetByTeacherNumber(TeacherNumber);


        public Task<bool> IsExistsByIdAsync(int id) => _repo.IsExistsByIdAsync(id);


        public Task<bool> IsExistsByTeacherIDAsync(int TeacherID) => _repo.IsExistsByTeacherIDAsync(TeacherID);


        public Task<bool> IsExistsByTeacherNumberAsync(string TeacherNumber) => _repo.IsExistsByTeacherNumberAsync(TeacherNumber);


        /*        public async Task<bool> AddAsync(AddEmplyementDetailCommandDTO entity)
        {
            // Validate the incoming details entity to ensure it meets all required criteria.
            await _AddValidations(entity.TeacherNumber);


            // Map the DTO (Data Transfer Object) to the Course entity.
            var Details = _mapper.Map<EmploymentDetail>(entity);


            //Add the details and return result
            return await _repo.AddAsync(Details) != 0;
        }*/


        /*public async Task<bool> AddRangeAsync(ICollection<AddEmplyementDetailCommandDTO> entities)
        {
            List<EmploymentDetail> details = new List<EmploymentDetail>();

            foreach (var item in entities)
            {
                await _AddValidations(item.TeacherNumber);

                details.Add(_mapper.Map<EmploymentDetail>(item));

            }
            return await _repo.AddRangeAsync(details);
        }*/


        public async Task<bool> UpdateAsync(string TeacherNumber, UpdateEmployementDetailsCommandDTO entity)
        {
            // Validate the incoming techer number exist.
            var details = await _EmploymentDetailValidation(TeacherNumber);

            // Map the DTO (Data Transfer Object) to the details entity
            details = _mapper.Map(entity, details);


            // Update the details  and return result
            return await _repo.UpdateAsync(details);
        }


        public IQueryable<EmploymentDetail> GetEmploymentDetailsPage(int PageNumber = 1) => _repo.GetPage(PageNumber);


        public Task<PaginatingResult> GetPaginateInfo() => _repo.GetPaginateInfo();

        #endregion

        #region Abstraction
        private async Task _AddValidations(string TeacherNumber)
        {
            await _DuplicteTeacherNumberValidation(TeacherNumber);
            await _TeacherExistsValidation(TeacherNumber);
        }

        private async Task _TeacherExistsValidation(string TeacherNumber)
        {
            if (!await _IExistsTeacherSrevice.IsExistsByTeacherNumber(TeacherNumber))
                throw new TeacherNotExistsExceptoin(TeacherNumber);
        }

        private async Task _DuplicteTeacherNumberValidation(string TeacherNumber)
        {
            if (await IsExistsByTeacherNumberAsync(TeacherNumber))
                throw new DuplicateTeacherNumber(TeacherNumber);
        }

        private async Task<EmploymentDetail> _EmploymentDetailValidation(string TeacherNumber)
        {
            var details = await GetByTeacherNumber(TeacherNumber).FirstOrDefaultAsync();

            return details == null ? throw new NotExistsDetails(TeacherNumber) : details;

        }
        #endregion


        #region Idea(s)
        //public IQueryable<EmploymentDetail> GetEmployesByContractType(enContractType ContractType) => _repo.GetEmployesByContractType(ContractType);
        //public IQueryable<EmploymentDetail> GetEmployesByHiringDuration(DateTime StartDuration, DateTime EndDuration)=> _repo.GetEmployesByHiringDuration(StartDuration, EndDuration);
        //public IQueryable<EmploymentDetail> GetEmployesBySalaryRange(double min, double max) => _repo.GetEmployesBySalaryRange(min, max);
        //public IQueryable<EmploymentDetail> GetEmployesMonthlyHiring(MonthOfYear Month) => _repo.GetEmployesMonthlyHiring(Month);
        //public Task<bool> UpdateRangeAsync(ICollection<EmploymentDetail> entities) => _repo.UpdateRangeAsync(entities);

        #endregion
    }
}