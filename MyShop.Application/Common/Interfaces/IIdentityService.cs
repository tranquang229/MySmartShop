using MyShop.Application.Accounts.Commands.LoginAccount;
using MyShop.Application.Common.Models;

namespace MyShop.Application.Common.Interfaces;
public interface IIdentityService
{
    Task<string?> GetUserNameAsync(Guid userId);

    Task<bool> IsInRoleAsync(Guid userId, string role);

    Task<bool> AuthorizeAsync(Guid userId, string policyName);

    Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(Guid userId);

    Task<LoginAccountDto> Authenticate(string userName, string password);
}
