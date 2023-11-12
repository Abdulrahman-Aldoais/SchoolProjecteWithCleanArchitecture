using AutoMapper;
using School.Application.Features.Departments.Commands.Create;
using School.Application.Features.Departments.Dtos.Get;
using School.Domain.Entities;

namespace School.Application.Features.Departments.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, GetDepartmentOutput>().ReverseMap();
        }
    }
}
