using System.Reflection;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Persistence.Entities;

namespace ShopOfPryaniks.Persistence.Data;

public class PryanikiDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<CartEntity> Carts => Set<CartEntity>();
    public DbSet<PositionEntity> Positions => Set<PositionEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
