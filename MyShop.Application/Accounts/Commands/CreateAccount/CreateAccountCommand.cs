using MediatR;

namespace MyShop.Application.Accounts.Commands.CreateAccount;
public class CreateAccountCommand : IRequest<Guid>
{
    public string UserName { get; set; }

    public string FullName { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
