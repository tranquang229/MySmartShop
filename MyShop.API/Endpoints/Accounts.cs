using MediatR;
using MyShop.API.Infrastructure;
using MyShop.Application.Accounts.Commands.CreateAccount;
using MyShop.Application.Accounts.Commands.LoginAccount;
using MyShop.Application.Common.Models.Reponses;

namespace MyShop.API.Endpoints;

public class Accounts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateAccount,nameof(CreateAccount))
            .MapPost(LoginAccount, nameof(LoginAccount));
    }

    public async Task<Guid> CreateAccount(ISender sender, CreateAccountCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<ApiResponseDto<LoginAccountDto>> LoginAccount(ISender sender, LoginAccountCommand command)
    {
        return await sender.Send(command);
    }
}
