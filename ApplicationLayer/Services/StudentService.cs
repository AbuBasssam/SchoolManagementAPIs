using ApplicationLayer.Features.Students.Commands.AddNewStudent;
using ApplicationLayer.Features.Students.Helper;
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
    public class StudentService : IStudentService
    {
        #region Field(s)

        private readonly IStudentRepository _studentRepository;
        private readonly IGeneralUserService _generalUserServices;
        private readonly IPersonExistsService _personExistsService;
        private readonly IAddUserService _addUserService;
        private IMapper _mapper;

        #endregion

        #region Constructure(s)
        public StudentService(IStudentRepository studentRepository, IPersonRepository personExistsService,
            IGeneralUserService changPassword, IAddUserService userService, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _generalUserServices = changPassword;
            _personExistsService = personExistsService;
            _addUserService = userService;
            _mapper = mapper;
        }
        #endregion

        #region Action Method(s)

        public IQueryable<Student> GetById(int id)
        => _studentRepository.GetById(id);

        public IQueryable<Student> GetByNationalNO(string NationalNo)
            => _studentRepository.GetByNationalNO(NationalNo);

        public IQueryable<Student> GetByStudentNumber(string studentNumber)
            => _studentRepository.GetByStudentNumber(studentNumber);

        public IQueryable<Student> GetStudentsPage(int pageNumber)
            => _studentRepository.GetPage(pageNumber);

        public async Task<bool> AddAsync(AddStudentDTO Student)
        {
            await _UniqueNationalNoValidation(Student.InfoDTO.NationalNO);
            var entity = _mapper.Map<Student>(Student);

            using (var Transaction = _studentRepository.BeginTransaction())
            {
                try
                {
                    entity.UserInfo = _AddStudentUserInfo(entity.UserInfo);

                    entity.UserInfo = _DefalutStudentUserSetting(entity.UserInfo);


                    IdentityResult AddUserResult = await _addUserService.AddNewUserAsync(entity.UserInfo, entity.UserInfo.PasswordHash!);

                    _AddingUserResult(AddUserResult);// if false will throws erros

                    await _AddStudentInfo(entity, entity.UserInfo.Id);
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

        public async Task<bool> AddRangeAsync(ICollection<Student> entities)
            => await _studentRepository.AddRangeAsync(entities);

        public async Task<PaginatingResult> GetPaginateInfo()
            => await _studentRepository.GetPaginateInfo();

        public async Task<bool> IsExistsById(int Id)
            => await _studentRepository.IsExistsByIdAsync(Id);

        public async Task<bool> IsExistsByNationalNo(string NationalNo)
            => await _personExistsService.IsExistsByNationalNo(NationalNo);

        public async Task<bool> IsExistsByStudentNumber(string StudentNumber)
        => await _studentRepository.IsExistsByStudentNumber(StudentNumber);


        public async Task<bool> UpdateStudentInfoAsync(string StudentNumber, UpdateInfoDTO entity)
        {
            var Student = await _CheckStudentExists(StudentNumber);

            return await _generalUserServices.UpdateUserInfoAsync(Student.UserInfo.UserName!, entity);

        }

        public async Task<bool> UpdateRange(ICollection<Student> entities)
         => await _studentRepository.UpdateRangeAsync(entities);

        public async Task<bool> ChangePasswordAsync(string StudnetNumber, string CurrentPassword, string NewPassword)
            => await IsExistsByStudentNumber(StudnetNumber) ?
             await _generalUserServices.ChangePasswordAsync(StudnetNumber, CurrentPassword, NewPassword) :
             throw new StudentExistsException(StudnetNumber);
        #endregion

        #region Abstraction
        private User _AddStudentUserInfo(User UserInfo)
        {
            UserInfo.UserName = _GenerateStudentNumber();
            UserInfo.RoleID = (int)enRole.Student;
            UserInfo.NormalizedUserName = UserInfo.UserName;
            return UserInfo;
        }

        private string _GenerateStudentNumber()
        {
            // Get the last two digits of the current year
            string yearSuffix = DateTime.Now.Year.ToString().Substring(2, 2);

            // Generate a random 8-digit number
            Random random = new Random();
            int randomNumber = random.Next(10000000, 100000000); // Generates a number between 10000000 and 100000000

            // Combine year suffix with random number
            return yearSuffix + randomNumber.ToString();
        }

        private User _DefalutStudentUserSetting(User UserInfo)
        {
            UserInfo.IsActive = true;
            UserInfo.Email = UserInfo.UserName is not null ? UserInfo.UserName + "@example.com" : null;
            UserInfo.NormalizedEmail = UserInfo.Email?.ToUpper();
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

        private async Task<bool> _AddStudentInfo(Student student, int UserID)
        {
            student.EnrollmentDate = DateTime.Now;

            student.GradeLevel = enLevel.FirstGrade;

            student.UserID = UserID;

            student.UserInfo = null!;// null;

            return await _studentRepository.AddAsync(student) != 0;

        }

        private void _AddingUserResult(IdentityResult AddUserResult)
        {
            if (!AddUserResult.Succeeded)
                throw new FailedCreateUser($"Failed to create student: {string.Join(", ", AddUserResult.Errors.Select(e => e.Description))}");
        }

        private async Task _UniqueNationalNoValidation(string NationalNO)
        {
            if (await _personExistsService.IsExistsByNationalNo(NationalNO))
                throw new DuplicateNationalNoException(NationalNO);

        }

        private async Task<Student> _CheckStudentExists(string StudentNumber)
        {
            var student = await _studentRepository.GetByStudentNumber(StudentNumber)
                .Include(s => s.UserInfo)
                .ThenInclude(ui => ui.PersonInfo)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return (student is null) ? throw new StudentExistsException(StudentNumber) : student;


        }

        public Task<bool> DeleteAsync(Student student)
        => _studentRepository.DeleteAsync(student);
        #endregion
    }

}
