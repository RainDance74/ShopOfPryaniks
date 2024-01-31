using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ShopOfPryaniks.Persistence.Data;

namespace ShopOfPryaniks.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddDbContext<PryanikiDbContext>(options =>
        {
            options.UseInMemoryDatabase("Pryaniki");
        });

        return services;
    }
}
