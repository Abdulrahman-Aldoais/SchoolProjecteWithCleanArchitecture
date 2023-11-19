using School.Domain.Resources;

namespace Core.Application.Responses
{
    public class BaseCommandBaseCommandResponseHandler
    {
        public BaseCommandResponse<string> Deleted<T>(string Message = null)
        {
            return new BaseCommandResponse<string>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Success = true,
                Message = Message == null ? SharedResourcesKeys.Deleted : Message
            };
        }
        public BaseCommandResponse<T> Success<T>(T entity, object Meta = null)
        {
            return new BaseCommandResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Success = true,
                Message = SharedResourcesKeys.Success,
                Meta = Meta
            };
        }
        public BaseCommandResponse<string> Unauthorized<T>(string Message = null)
        {
            return new BaseCommandResponse<string>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Success = true,
                Message = Message == null ? SharedResourcesKeys.UnAuthorized : Message
            };
        }
        public BaseCommandResponse<T> BadRequest<T>(string Message = null)
        {
            return new BaseCommandResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Success = false,
                Message = Message == null ? SharedResourcesKeys.BadRequest : Message
            };
        }

        public BaseCommandResponse<string> UnprocessableEntity<T>(string Message = null)
        {
            return new BaseCommandResponse<string>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Success = false,
                Message = Message == null ? SharedResourcesKeys.UnprocessableEntity : Message
            };
        }


        public BaseCommandResponse<string> NotFound<T>(string message = null)
        {
            return new BaseCommandResponse<string>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Success = false,
                Message = message == null ? SharedResourcesKeys.NotFound : message
            };
        }

        public BaseCommandResponse<T> Created<T>(T entity, object Meta = null)
        {
            return new BaseCommandResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Success = true,
                Message = SharedResourcesKeys.Created,
                Meta = Meta
            };
        }
    }
}
