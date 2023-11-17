using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Repositories.UserRepository;
using School.Application.Service.UserService;
using School.Domain.Entities;
using School.Domain.Resources;

namespace School.Application.Features.User.Command.Create
{
    public class CreateUserCommandHandler : BaseCommandBaseCommandResponseHandler,
        IRequestHandler<CreateUserCommand, BaseCommandResponse<string>>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {

            _mapper = mapper;
            _userService = userService;
        }


        public async Task<BaseCommandResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //var response = new BaseCommandResponse<GetUserOutput>();
            //var validator = new CreateUserCommandHandlerValidation();
            //var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            //if (!validatorResult.IsValid)
            //{
            //    response.Data = null;
            //    response.Success = false;
            //    response.Message = "";
            //    response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            //}
            var identityUserMapp = _mapper.Map<ApplicationUser>(request);
            var createResult = await _userService.AddUserAsync(identityUserMapp, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(SharedResourcesKeys.EmailIsExist);
                case "UserNameIsExist": return BadRequest<string>(SharedResourcesKeys.UserNameIsExist);
                case "ErrorInCreateUser": return BadRequest<string>(SharedResourcesKeys.FaildToAddUser);
                case "Failed": return BadRequest<string>(SharedResourcesKeys.TryToRegisterAgain);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createResult);
            }
        }


    }
}
