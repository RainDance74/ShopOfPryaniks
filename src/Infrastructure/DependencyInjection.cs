using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Constants;
using ShopOfPryaniks.Infrastructure.Data;
using ShopOfPryaniks.Infrastructure.Identity;

namespace ShopOfPryaniks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if(string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "You must specify \"DefaultConnection\" in the configuration first.");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
            opt.DefaultChallengeScheme = IdentityConstants.BearerScheme;
            opt.DefaultScheme = IdentityConstants.BearerScheme;
        })
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddTransient<IIdentityService, IdentityService>();

        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
        });

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanManage, policy => policy.RequireRole(Roles.Administrator)));

        return services;
    }
}
