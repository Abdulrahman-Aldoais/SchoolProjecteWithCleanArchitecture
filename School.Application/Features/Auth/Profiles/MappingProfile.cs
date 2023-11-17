using AutoMapper;
using School.Application.Features.Auth.Dto.GetLogin;
using School.Domain.Entities;

namespace School.Application.Features.Auth.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, GetLoginOutput>().ReverseMap();
        }
    }
}