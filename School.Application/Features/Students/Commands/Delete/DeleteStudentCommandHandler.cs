using Core.Application.Responses;
using MediatR;
using System.Net;

namespace School.Application.Features.Students.Commands.Delete
{

    public class DeleteStudentCommandHandler : BaseCommandBaseCommandResponseHandler,
        IRequestHandler<DeleteStudentCommand, BaseCommandResponse<string>>
    {

        #region Fields

        private readonly HttpClient _httpClient;


        #endregion

        #region Constructors
        public DeleteStudentCommandHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        public async Task<BaseCommandResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {

            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync("https://localhost:7014/api/Student/Api/v1/Student/" + request.Id);

            var responseData = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                if (responseData == "Delete Success") return Deleted<string>();
            }
            else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound<string>();
            }
            else if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest<string>();
            }
            return BadRequest<string>();

        }
    }

}
