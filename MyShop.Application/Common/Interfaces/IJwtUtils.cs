using MyShop.Application.Accounts.Commands.LoginAccount;

namespace MyShop.Application.Common.Interfaces;
public interface IJwtUtils
{
    public string GenerateJwtToken(LoginAccountDto account);
 
    //public Guid ValidateJwtToken(string token);
}
