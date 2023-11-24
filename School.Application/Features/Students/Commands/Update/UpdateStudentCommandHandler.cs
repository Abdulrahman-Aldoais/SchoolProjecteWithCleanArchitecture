using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Students.Dtos.Get;
using School.Application.Service.StudentServices;
using School.Domain.Resources;

namespace School.Application.Features.Students.Commands.Update
{

    public class UpdateStudentCommandHandler : BaseCommandBaseCommandResponseHandler,
        IRequestHandler<UpdateStudentCommand, BaseCommandResponse<GetStudentOutput>>
    {

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public UpdateStudentCommandHandler(
            IMapper mapper,
            IStudentService studentService)
        {

            _mapper = mapper;
            _studentService = studentService;
        }
        public async Task<BaseCommandResponse<GetStudentOutput>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetStudentOutput>();
            var validator = new UpdateStudentCommandHandlerValidation();
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

                //Check if the Id is Exist Or not
                var student = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);

                //return NotFound
                if (student == null) return BadRequest<GetStudentOutput>(SharedResourcesKeys.UserIsNotFound);
                //mapping Between request and student
                var studentmapper = _mapper.Map(request, student);
                //Call service that make Edit
                var result = await _studentService.UpdateStudentInfo(studentmapper);
                //return response
                if (result == "Success") return Success(response.Data, SharedResourcesKeys.Updated);
                //Success<GetStudentOutput>(response.Data);
                else return BadRequest<GetStudentOutput>(SharedResourcesKeys.UpdateFailed);
            }
            return response;
        }
    }
}
