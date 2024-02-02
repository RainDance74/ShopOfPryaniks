using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Infrastructure.Data.Configurations;
public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder) => builder.ConfigureBase();
}
