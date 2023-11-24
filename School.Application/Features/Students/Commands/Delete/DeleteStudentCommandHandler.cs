using AutoMapper;
using Core.Application.Responses;
using MediatR;
using School.Application.Service.StudentServices;
using School.Persistence.Repositories.StudentRepository;

namespace School.Application.Features.Students.Commands.Delete
{

    public class DeleteStudentCommandHandler : BaseCommandBaseCommandResponseHandler,
        IRequestHandler<DeleteStudentCommand, BaseCommandResponse<string>>
    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DeleteStudentCommandHandler(IStudentService studentService,
                                     IMapper mapper, IStudentWriteRepository studentWriteRepository
            , IStudentReadRepository studentReadRepository)
        {
            _studentService = studentService;
            _mapper = mapper;
            _studentWriteRepository = studentWriteRepository;
            _studentReadRepository = studentReadRepository;

        }
        #endregion

        public async Task<BaseCommandResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var studentResult = await _studentReadRepository.GetAsync(x => x.Id.Equals(request.Id));
            //return NotFound
            if (studentResult == null) return NotFound<string>();
            //Call service that make Delete
            var result = await _studentService.DeleteAsync(studentResult);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();

        }
    }

}
