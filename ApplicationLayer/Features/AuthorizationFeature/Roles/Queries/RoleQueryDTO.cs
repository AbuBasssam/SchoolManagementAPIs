using AutoMapper;
using DomainLayer.Entities;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

public class RoleQueryDTO
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleQueryDTO>();
        }
    }
}
