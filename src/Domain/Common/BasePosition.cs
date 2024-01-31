using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.Common;

public abstract class BasePosition : BaseEntity
{
    public Product Product { get; set; } = null!;
    private protected int _amount = 1;
    public int Amount
    {
        get => _amount;
        set => _amount = Math.Max(value, 1);
    }
}
