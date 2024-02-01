using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Infrastructure.Identity;

namespace ShopOfPryaniks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserManager, UserManagerService>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if(string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "You must specify \"DefaultConnection\" in the configuration first.");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

        services.AddDefaultIdentity<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        return services;
    }
}
