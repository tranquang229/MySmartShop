using MediatR;
using MyShop.Application.Common.Interfaces;
using MyShop.Application.Common.Models;
using MyShop.Application.Common.Models.Reponses;

namespace MyShop.Application.Accounts.Commands.LoginAccount;
public class LoginAccountCommandHandler: IRequestHandler<LoginAccountCommand, ApiResponseDto<LoginAccountDto>>
{

    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IJwtUtils _jwtUtils;

    public LoginAccountCommandHandler(IApplicationDbContext context, IIdentityService identityService, IJwtUtils jwtUtils)
    {
        _context = context;
        _identityService = identityService;
        _jwtUtils = jwtUtils;
    }


    public async Task<ApiResponseDto<LoginAccountDto>> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
    {
        var account =  await _identityService.Authenticate(request.UserName, request.Password);

        if (account == null)
        {
            return new ApiResponseDto<LoginAccountDto>
            {
                Message = "Email or password is incorrect"
            };
        }

        // authentication successful so generate jwt and refresh tokens
        var jwtToken = _jwtUtils.GenerateJwtToken(account);
        account.Token = jwtToken;

        return new OkApiResponseDto<LoginAccountDto>(string.Empty, account);
    }
}
