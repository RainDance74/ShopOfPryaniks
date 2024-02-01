using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Persistence.Data;

namespace ShopOfPryaniks.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if(string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "You must specify \"DefaultConnection\" in the configuration first.");
        }

        services.AddDbContext<PryanikiDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IPryanikiDbContext>(provider => provider.GetRequiredService<PryanikiDbContext>());

        services.AddScoped<PryanikiDbContextInitialiser>();

        return services;
    }
}
