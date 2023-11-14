using AutoMapper;
using School.Application.Features.ApplicationUser.Command.Create;
using School.Domain.Entities;

namespace School.Application.Features.ApplicationUser.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
