using System.Net;

namespace MyShop.Application.Common.Models.Reponses;
public class NotFoundResponseDto<T> : ApiResponseDto<T>
{
    public NotFoundResponseDto(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        Message = message;
    }
}
