using AutoMapper;
using MyShop.Application.Accounts.Commands.LoginAccount;
using MyShop.Infrastructure.Identity;

namespace MyShop.Infrastructure.Helpers;

public class AutoMapperProfile : Profile
{
    // mappings between model and entity objects
    public AutoMapperProfile()
    {
        CreateMap<ApplicationUser, LoginAccountDto>();
    }
}