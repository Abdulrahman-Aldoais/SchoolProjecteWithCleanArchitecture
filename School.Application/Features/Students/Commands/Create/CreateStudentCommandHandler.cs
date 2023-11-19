using AutoMapper;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using School.Application.Features.Departments;
using School.Application.Features.Students.Dtos.Get;

using School.Domain.Entities;
using School.Persistence.Repositories.StudentRepository;
using System.Security.Claims;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse<GetStudentOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateStudentCommandHandler(

            IMapper mapper,
            IStudentReadRepository studentReadRepository,
            IStudentWriteRepository studentWriteRepository,
            IHttpContextAccessor contextAccessor
            )
        {
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _contextAccessor = contextAccessor;
        }
        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new CreateStudentCommandHandlerValidatior(_studentReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {

                var studentMapp = _mapper.Map<Student>(request);
                studentMapp.CreatedBy = UserId;
                var result = await _studentWriteRepository.AddAsync(studentMapp);
                var resultMapp = _mapper.Map<GetStudentOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = DepartmentMessages.CreatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}