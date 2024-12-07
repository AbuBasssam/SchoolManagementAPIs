using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.AddRole;

public class AddRoleCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = null!;

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddRoleCommand, Role>();
        }
    }
}
