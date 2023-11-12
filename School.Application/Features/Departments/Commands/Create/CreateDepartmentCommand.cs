using Core.Application.Responses;
using MediatR;
using School.Application.Features.Departments.Dtos.Get;

namespace School.Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommand : IRequest<BaseCommandResponse<GetDepartmentOutput>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
