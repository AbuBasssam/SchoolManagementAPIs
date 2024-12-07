using ApplicationLayer.Features.User.Queries;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.UserFeature.Commands.AddAdminCommand
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response<UserQueryDTO>>
    {
        private readonly IUserService _service;
        private readonly ResponseHandler _response;
        private readonly IMapper _mapper;


        public AddUserCommandHandler(IUserService service, ResponseHandler response, IMapper mapper)
        {
            _service = service;
            _response = response;
            _mapper = mapper;
        }

        public async Task<Response<UserQueryDTO>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<DomainLayer.Entities.User>(request.DTO);
            User = AddAdminUserInfo(User);
            User = DefalutTeacherSetting(User);


            var IsAdded = await _service.AddNewUserAsync(User, User.PasswordHash!);
            if (IsAdded.Succeeded)
            {
                var NewUser = await _service.GetByNationalNO(request.DTO.InfoDTO.NationalNO).Select(UserQueryHelper.UserDTOMap()).FirstAsync();
                return _response.Created(NewUser);
            }
            return _response.BadRequest<UserQueryDTO>("Add Failed");

        }
        private DomainLayer.Entities.User AddAdminUserInfo(DomainLayer.Entities.User UserInfo)
        {
            UserInfo.UserName = GenerateAdminNumber();
            UserInfo.RoleID = (int)enRole.Admin;
            UserInfo.NormalizedUserName = UserInfo.UserName;
            return UserInfo;
        }

        private string GenerateAdminNumber()
        {
            // Get the last two digits of the current year
            string yearSuffix = DateTime.Now.AddYears(-3).Year.ToString().Substring(2, 2);

            // Generate a random 8-digit number
            Random random = new Random();
            int randomNumber = random.Next(10000000, 100000000); // Generates a number between 10000000 and 100000000

            // Combine year suffix with random number
            return yearSuffix + randomNumber.ToString();
        }

        private DomainLayer.Entities.User DefalutTeacherSetting(DomainLayer.Entities.User UserInfo)
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
    }
}
