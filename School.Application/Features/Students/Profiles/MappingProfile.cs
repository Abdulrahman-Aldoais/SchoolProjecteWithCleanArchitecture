using AutoMapper;
using School.Application.Features.Students.Commands.Create;
using School.Application.Features.Students.Dtos.Get;
using School.Domain.Entities;

namespace School.Application.Features.Students.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, GetStudentOutput>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
        }
    }
}
