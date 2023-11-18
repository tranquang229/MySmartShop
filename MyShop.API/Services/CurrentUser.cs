using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.Common.Interfaces;
using MyShop.Domain.Common;
using MyShop.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyShop.API.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;

    public CurrentUser(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        _appSettings = appSettings.Value;
    }

    public Guid Id
    {
        get
        {
            //if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)))
            //{
            //    return Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
            //}
            //return Guid.Empty;
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();
            var accountId = ValidateJwtToken(token);
            
            return accountId;
        }
    }

    public Guid ValidateJwtToken(string token)
    {
        if (token == null)
            return Guid.Empty;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // return account id from JWT token if validation successful
            return accountId;
        }
        catch(Exception ex) 
        {
            // return null if validation fails
            return Guid.Empty;
        }
    }
}
