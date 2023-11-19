using AutoMapper;
using Core.Application.FormAuth.ClaimServices;
using Core.Application.FormAuth.CookieScheme;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Application.Features.Auth.Constants;
using School.Application.Features.Auth.Dto.GetLogin;

using School.Domain.Entities;
using School.Domain.Resources;
using School.Persistence.Repositories.UserRepository;

namespace School.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseCommandResponse<GetLoginOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IClaimCoreService _claimService;
        private readonly IUserReadRepository _userReadRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public LoginUserCommandHandler(
            IMapper mapper,
            IClaimCoreService claimService,
            IUserReadRepository userReadRepository,
            UserManager<ApplicationUser> userManager,

            SignInManager<ApplicationUser> signInManager
            )
        {
            _mapper = mapper;
            _claimService = claimService;
            _userReadRepository = userReadRepository;
            _userManager = userManager;

            _signInManager = signInManager;
        }

        public async Task<BaseCommandResponse<GetLoginOutput>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserCommandHandlerValidatior(_userReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new BaseCommandResponse<GetLoginOutput>
                {
                    Success = false,
                    Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new BaseCommandResponse<GetLoginOutput>
                {
                    Success = false,
                    Message = SharedResourcesKeys.NotFound
                };
            }

            var resultCreateUser = await _userReadRepository.GetAsync(x => x.Email == request.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                return new BaseCommandResponse<GetLoginOutput>
                {
                    Success = false,
                    Message = SharedResourcesKeys.AddFailed
                };
            }

            await _claimService.CreateAsync(new Core.Application.FormAuth.ClaimInfo.ClaimCoreInfo
            {
                UserId = resultCreateUser.Id,
                RememberMe = request.RememberMe,
                Email = resultCreateUser.Email,
                Task = resultCreateUser.Task,
                FirstName = resultCreateUser.FullName
            }, AuthDefaults.Scheme);


            var resultMapp = _mapper.Map<GetLoginOutput>(resultCreateUser);

            var idUser = new Guid(resultCreateUser.Id);
            return new BaseCommandResponse<GetLoginOutput>
            {
                Id = idUser,
                Data = resultMapp,
                Success = true,
                Message = AuthMessages.EmailOrPassCorrect,
                Errors = null
            };
        }
    }
}
