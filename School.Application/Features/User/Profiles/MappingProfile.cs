using AutoMapper;
using School.Application.Features.User.Command.Create;
using School.Application.Features.User.Dtos.GetList;
using School.Domain.Entities;

namespace School.Application.Features.User.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, CreateUserCommand>().ReverseMap();
            CreateMap<ApplicationUser, GetUserListOutput>().ReverseMap();
        }
    }
}
