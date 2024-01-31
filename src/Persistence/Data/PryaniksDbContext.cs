using System.Reflection;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Data;

public class PryanikiDbContext(DbContextOptions options) : DbContext(options), IPryanikiDbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<BasePosition> Positions => Set<BasePosition>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
