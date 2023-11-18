namespace MyShop.Application.Accounts.Commands.CreateAccount;
public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(v => v.UserName)
            .MinimumLength(5)
            .MaximumLength(200)
            .NotEmpty();
    }
}
