using ApplicationLayer.Features.Students.Helper;
using ApplicationLayer.Features.Teachers.Commands.AddNewTeacher;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.Exceptoins.Student;
using DomainLayer.Exceptoins.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class TeacherService : ITeacherService
    {
        #region Field(s)
        private readonly ITeacherRepository _repo;
        private readonly IGeneralUserService _generalUserServices;
        private readonly IAddUserService _userService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructure(s)
        public TeacherService(ITeacherRepository repo, IGeneralUserService generalUserServices, IAddUserService userService, IMapper mapper)
        {
            _repo = repo;
            _generalUserServices = generalUserServices;
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region Action Method(s)
        public IQueryable<Teacher> GetById(int id)
        => _repo.GetById(id);

        public IQueryable<Teacher> GetByNationalNO(string NationalNo)
            => _repo.GetByNationalNO(NationalNo);

        public IQueryable<Teacher> GetByTeacherNumber(string TeacherNumber)
            => _repo.GetByUserName(TeacherNumber);

        public IQueryable<Teacher> GetTeacherPage(int pageNumber)
            => _repo.GetPage(pageNumber);

        public async Task<PaginatingResult> GetPaginateInfo()
            => await _repo.GetPaginateInfo();

        public async Task<bool> AddAsync(AddTeacherDTO Teacher)
        {
            await _UniqueNationalNoValidation(Teacher.InfoDTO.NationalNO);
            Teacher entity = _mapper.Map<Teacher>(Teacher);

            using (var Transaction = _repo.BeginTransaction())
            {
                try
                {
                    entity.UserInfo = AddTeacherUserInfo(entity.UserInfo);

                    entity.UserInfo = DefalutTeacherSetting(entity.UserInfo);

                    IdentityResult AddUserResult = await _userService.AddNewUserAsync(entity.UserInfo, entity.UserInfo.PasswordHash!);

                    _AddingUserResult(AddUserResult);// if false will throws erros

                    await AddTeacherInfo(entity, entity.UserInfo.Id);
                    Transaction.Commit();
                    return true;
                }
                catch
                {
                    Transaction.Rollback();
                    return false;
                }
            }

        }

        public async Task<bool> AddRangeAsync(ICollection<Teacher> entities)
            => await _repo.AddRangeAsync(entities);

        public async Task<bool> IsExistsByNationalNo(string NationalNo)
            => await _repo.IsExistsByNationalNo(NationalNo);

        public async Task<bool> IsExistsByTeacherNumber(string TeacherNumber)
            => await _repo.IsExistsByTeacherNumber(TeacherNumber);

        public async Task<bool> UpdateTeacherInfoAsync(string TeacherNumber, UpdateInfoDTO entity)
        {
            var Teacher = await _CheckTeacherExists(TeacherNumber);

            return await _generalUserServices.UpdateUserInfoAsync(Teacher.UserInfo.UserName!, entity);
        }

        public async Task<bool> UpdateRange(ICollection<Teacher> entities)
             => await _repo.UpdateRangeAsync(entities);

        public async Task<bool> ChangePasswordAsync(string TeacherNumber, string CurrentPassword, string NewPassword)
        {
            return await IsExistsByTeacherNumber(TeacherNumber) ?
            await _generalUserServices.ChangePasswordAsync(TeacherNumber, CurrentPassword, NewPassword) :
            throw new TeacherNotExistsException(TeacherNumber);

        }

        public Task<bool> DeleteAsync(Teacher teacher)
            => _repo.DeleteAsync(teacher);

        #endregion

        #region Abstraction
        private void _AddingUserResult(IdentityResult AddUserResult)
        {
            if (!AddUserResult.Succeeded)
                throw new FailedCreateUser($"Failed to create teacher : {string.Join(", ", AddUserResult.Errors.Select(e => e.Description))}");
        }

        private async Task _UniqueNationalNoValidation(string NationalNO)
        {
            if (await _repo.IsExistsByNationalNo(NationalNO))
                throw new DuplicateNationalNoException(NationalNO);

        }

        public User AddTeacherUserInfo(User UserInfo)
        {
            UserInfo.UserName = GenerateTeacherNumber();
            UserInfo.RoleID = (int)enRole.Teacher;
            UserInfo.NormalizedUserName = UserInfo.UserName;
            return UserInfo;
        }

        private string GenerateTeacherNumber()
        {
            // Get the last two digits of the current year
            string yearSuffix = DateTime.Now.AddYears(-2).Year.ToString().Substring(2, 2);

            // Generate a random 8-digit number
            Random random = new Random();
            int randomNumber = random.Next(10000000, 100000000); // Generates a number between 10000000 and 100000000

            // Combine year suffix with random number
            return yearSuffix + randomNumber.ToString();
        }

        private User DefalutTeacherSetting(User UserInfo)
        {
            UserInfo.IsActive = true;
            UserInfo.NormalizedEmail = UserInfo.Email!.ToUpper();
            UserInfo.EmailConfirmed = false;
            UserInfo.SecurityStamp = Guid.NewGuid().ToString();
            UserInfo.ConcurrencyStamp = Guid.NewGuid().ToString();
            UserInfo.PhoneNumberConfirmed = false;
            UserInfo.TwoFactorEnabled = false;
            UserInfo.LockoutEnd = null;
            UserInfo.LockoutEnabled = false;
            UserInfo.AccessFailedCount = 0;
            return UserInfo;
        }

        private async Task<bool> AddTeacherInfo(Teacher teacher, int UserID)
        {
            teacher.EmploymentDetails.HiringDate = DateTime.Now;

            teacher.UserID = UserID;

            teacher.UserInfo = null!;//null

            return await _repo.AddAsync(teacher) != 0;

        }

        private async Task<Teacher> _CheckTeacherExists(string TeacherNumber)
        {
            var teacher = await _repo.GetByUserName(TeacherNumber).Include(t => t.UserInfo).ThenInclude(ui => ui.PersonInfo).AsNoTracking().FirstOrDefaultAsync();

            return (teacher is not null) ? teacher : throw new TeacherNotExistsException(TeacherNumber);


        }
        #endregion
    }

}
