namespace MyShop.Application.Accounts.Commands.LoginAccount;
public class LoginAccountDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; }
    public string Email { get; set; }

    public string Token { get; set; }
}
