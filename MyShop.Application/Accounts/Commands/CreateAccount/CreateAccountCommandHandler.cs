using MediatR;
using MyShop.Application.Common.Interfaces;

namespace MyShop.Application.Accounts.Commands.CreateAccount;
public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public CreateAccountCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var userCreated = await _identityService.CreateUserAsync(request.UserName, request.Password);

        return userCreated.UserId;
    }
}
