using ApplicationLayer.Models;
using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Helper_Classes;
using MediatR;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Commands.SignIn;

public class SignInCommand : IRequest<Response<JwtAuthResult>>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SignInCommand, User>();
        }
    }
}
