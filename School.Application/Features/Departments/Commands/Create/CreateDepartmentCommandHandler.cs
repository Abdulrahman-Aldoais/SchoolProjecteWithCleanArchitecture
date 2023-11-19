using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Features.Departments.Dtos.Get;
using School.Domain.Entities;
using School.Persistence.Repositories.DepartmentRepository;

namespace School.Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseCommandResponse<GetDepartmentOutput>>
    {
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IMapper _mapper;
        public CreateDepartmentCommandHandler(
            IDepartmentReadRepository departmentReadRepository,
            IDepartmentWriteRepository departmentWriteRepository,
            IMapper mapper
            )
        {
            _departmentReadRepository = departmentReadRepository;
            _departmentWriteRepository = departmentWriteRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<GetDepartmentOutput>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetDepartmentOutput>();
            var validator = new CreateDepartmentCommandHandlerValidation(_departmentReadRepository);
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
                var departmentMap = _mapper.Map<Department>(request);
                var result = await _departmentWriteRepository.AddAsync(departmentMap);
                var resultMapp = _mapper.Map<GetDepartmentOutput>(result);
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
