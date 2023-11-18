using MediatR;
using MyShop.Application.Common.Models.Reponses;

namespace MyShop.Application.Accounts.Commands.LoginAccount;
public class LoginAccountCommand : IRequest<ApiResponseDto<LoginAccountDto>>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
