using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Application.Common.Interfaces;
using MyShop.Domain.Common;
using MyShop.Infrastructure.Data;
using MyShop.Infrastructure.Data.Interceptors;
using MyShop.Infrastructure.Identity;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyShop.Domain.Constants;

namespace MyShop.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // configure strongly typed settings object
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));


        //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();


        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IJwtUtils, JwtUtils>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Admin)));



        //services.AddAuthentication()
        //    .AddBearerToken(IdentityConstants.BearerScheme);

        //services.AddAuthorizationBuilder();

        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => configuration.Bind("AppSettings", options));

        //services.AddAuthorization(options =>
        //    options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        //services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        //        options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        //        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        //    })
        //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => configuration.Bind("AppSettings", options));

        return services;
    }
}
