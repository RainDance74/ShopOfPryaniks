using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Infrastructure.Data.Configurations;
internal class PositionConfiguration : IEntityTypeConfiguration<BasePosition>
{
    public void Configure(EntityTypeBuilder<BasePosition> builder) => builder.ConfigureBase();
}
