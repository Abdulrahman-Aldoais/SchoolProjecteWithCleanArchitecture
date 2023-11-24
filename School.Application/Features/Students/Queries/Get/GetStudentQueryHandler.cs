
using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Constants;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Service.StudentServices;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Queries.Get
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, BaseCommandResponse<GetStudentOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IStudentReadRepository _studentReadRepository;

        public GetStudentQueryHandler(IMapper mapper, IStudentService studentService, IStudentReadRepository studentReadRepository)
        {
            _mapper = mapper;
            _studentService = studentService;
            _studentReadRepository = studentReadRepository;
        }

        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new GetStudentQueryHandlerValidatior(_studentReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var result = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);
                var resultMapp = _mapper.Map<GetStudentOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StudentMessages.GetByIdExists;
                response.Errors = null;
            }
            return response;
        }
    }
}