using System.Net;

namespace MyShop.Application.Common.Models.Reponses;
public class OkApiResponseDto<T> : ApiResponseDto<T>
{
    public OkApiResponseDto(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.OK;
        Message = message;
    }

    public OkApiResponseDto(string message, T result) : base(message, result)
    {
        StatusCode = (int)HttpStatusCode.OK;
        Message = message;
        Result = result;
    }
}
