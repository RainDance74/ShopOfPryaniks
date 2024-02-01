namespace ShopOfPryaniks.Domain.Common;

public abstract class BaseUser : BaseEntity
{
    public string UserId { get; set; } = default!;
}
