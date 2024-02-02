using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Infrastructure.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder) => builder.ConfigureBase();
}
