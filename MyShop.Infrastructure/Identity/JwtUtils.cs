using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.Accounts.Commands.LoginAccount;
using MyShop.Application.Common.Interfaces;
using MyShop.Domain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyShop.Infrastructure.Identity;
public class JwtUtils : IJwtUtils
{
    private readonly IApplicationDbContext _context;
    private readonly AppSettings _appSettings;

    public JwtUtils(IApplicationDbContext context, IOptions<AppSettings> appSettings)
    {
        _context = context;
        _appSettings = appSettings.Value;
    }

    public string GenerateJwtToken(LoginAccountDto account)
    {
        // generate token that is valid for 15 minutes
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", account.Id.ToString()),
                new Claim("userName", account.UserName),
                new Claim("email", account.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
       
        return tokenHandler.WriteToken(token);
    }

    
}