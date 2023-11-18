namespace MyShop.Application.Common.Models.Reponses;
public class ApiResponseDto<T>
{
    public int StatusCode { get; set; }

    public bool IsSuccessStatusCode => StatusCode >= 200 && StatusCode < 300;

    public string Message { get; set; }

    public List<string> Errors { get; set; } = new();

    public T Result { get; set; }

    public ApiResponseDto()
    {

    }

    public ApiResponseDto(string message)
    {
        Message = message;
    }

    public ApiResponseDto(string message, T result)
    {
        Message = message;
        Result = result;
    }

    public ApiResponseDto(string message, T result, List<string> errors)
    {
        Message = message;
        Result = result;
        Errors = errors;
    }

    public ApiResponseDto(string message, T result, List<string> errors, int statusCode)
    {
        Message = message;
        Result = result;
        Errors = errors;
        StatusCode = statusCode;
    }
}