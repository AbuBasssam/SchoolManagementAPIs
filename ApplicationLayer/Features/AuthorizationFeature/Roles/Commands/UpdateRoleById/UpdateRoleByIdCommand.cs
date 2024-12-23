﻿using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using MediatR;
using SchoolApp.Application.Features.AuthorizationFeature.Roles.Queries;

namespace SchoolApp.Application.Features.AuthorizationFeature.Roles.Commands.UpdateRoleById;

public class UpdateRoleByIdCommand : IRequest<Response<RoleQueryDTO>>
{
    public int Id { get; set; }
    public UpdateRoleByIdDTO RoleData { get; set; }

    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRoleByIdCommand, Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoleData.Name));
            CreateMap<Role, Role>();
        }
    }
}
