using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class CartPosition : BasePosition
{
    public int AvailableAmount => Math.Min(Product.Amount, Amount);
}
