using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.ApplicationUser.Dtos.Get;
using School.Application.Repositories.UserRepository;
using School.Application.Service.UserService;
using School.Domain.Entities;
using School.Domain.Resources;

namespace School.Application.Features.ApplicationUser.Command.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse<GetUserOutput>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
            _userService = userService;
        }

        //public async Task<BaseCommandResponse<GetUserOutput>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        //{
        //    var response = new BaseCommandResponse<GetUserOutput>();
        //    var valiator = new CreateUserCommandHandlerValidation(_userReadRepository);
        //    var validatorResult = await valiator.ValidateAsync(request);

        //    if (!validatorResult.IsValid)
        //    {
        //        response.Data = null;
        //        response.Success = false;
        //        response.Message = "";
        //        response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
        //    }
        //    else
        //    {
        //        var userMapp = _mapper.Map<User>(request);
        //        var result = await _userWriteRepository.AddAsync(userMapp);
        //        var resultMapp = _mapper.Map<GetUserOutput>(result);
        //        response.Id = resultMapp.Id;
        //        response.Data = resultMapp;
        //        response.Success = true;
        //        response.Message = UserMessages.CreatedSuccess;
        //        response.Errors = null;

        //    }

        //    return response;
        //}


        public async Task<BaseCommandResponse<GetUserOutput>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetUserOutput>();

            var identityUserMapp = _mapper.Map<User>(request);
            var createResult = await _userService.AddUserAsync(identityUserMapp, request.Password);
            var resultMapp = _mapper.Map<GetUserOutput>(createResult);
            switch (response.Message)
            {
                case "EmailIsExist":
                    response.Errors.Add(SharedResourcesKeys.EmailIsExist);
                    break;
                case "UserNameIsExist":
                    response.Errors.Add(SharedResourcesKeys.UserNameIsExist);
                    break;
                case "ErrorInCreateUser":
                    response.Errors.Add(SharedResourcesKeys.FaildToAddUser);
                    break;
                case "Failed":
                    response.Errors.Add(SharedResourcesKeys.TryToRegisterAgain);
                    break;
                case "Success":
                    response.Id = resultMapp.Id;
                    response.Success = true;
                    response.Data = _mapper.Map<GetUserOutput>(resultMapp);
                    response.Success = true;
                    response.Message = SharedResourcesKeys.Success;
                    response.Errors = null;
                    break;
                default:
                    response.Errors.Add(response.Message);
                    break;
            }

            return response;
        }



    }
}
