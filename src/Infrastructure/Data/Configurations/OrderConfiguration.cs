using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Infrastructure.Data.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder) => builder.ConfigureBase();
}
