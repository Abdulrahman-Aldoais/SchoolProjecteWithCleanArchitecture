using Core.Application.Responses;
using MediatR;

namespace School.Application.Features.Students.Commands.Delete
{
    public class DeleteStudentCommand : IRequest<BaseCommandResponse<string>>
    {
        public Guid Id { get; set; }
    }
}