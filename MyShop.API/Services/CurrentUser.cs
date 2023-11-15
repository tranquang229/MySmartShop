using System.Security.Claims;
using MyShop.Application.Common.Interfaces;

namespace MyShop.API.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id
    {
        get
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return Guid.Empty;
        }
    }
}
