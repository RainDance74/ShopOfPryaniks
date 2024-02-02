using System.Reflection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;
using ShopOfPryaniks.Infrastructure.Identity;

namespace ShopOfPryaniks.Infrastructure.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
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
