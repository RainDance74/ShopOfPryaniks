using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Persistence.Data;

namespace ShopOfPryaniks.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PryanikiDbContext>(options =>
        {
            options.UseInMemoryDatabase("Pryaniki");
        });

        services.AddScoped<IPryanikiDbContext>(provider => provider.GetRequiredService<PryanikiDbContext>());

        services.AddScoped<PryanikiDbContextInitialiser>();

        return services;
    }
}
