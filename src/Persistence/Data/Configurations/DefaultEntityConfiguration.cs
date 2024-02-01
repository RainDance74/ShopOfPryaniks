using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Persistence.Data.Configurations;

public static class DefaultEntityConfiguration
{
    public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder
            .HasKey(x => x.Id);
    }
}