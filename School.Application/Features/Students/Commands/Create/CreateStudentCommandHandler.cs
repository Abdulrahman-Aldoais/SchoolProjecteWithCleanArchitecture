using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Departments;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Repositories.StudentRepository;
using School.Domain.Entities;

namespace School.Application.Features.Students.Commands.Create
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse<GetStudentOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;

        public CreateStudentCommandHandler(

            IMapper mapper,
            IStudentReadRepository studentReadRepository,
            IStudentWriteRepository studentWriteRepository
            )
        {
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
        }

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