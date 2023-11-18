using System.Net;

namespace MyShop.Application.Common.Models.Reponses;
public class FailApiResponseDto<T> : ApiResponseDto<T>
{
    public FailApiResponseDto(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Message = message;
    }

    public FailApiResponseDto(string message, T result) : base(message, result)
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Message = message;
        Result = result;
    }
}
