using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class Order : BaseEntity
{
    public string ClientPhone { get; set; } = default!;
    public List<OrderPosition> Positions { get; } = [];
    public OrderStatus Status { get; set; }
    public decimal PriceTotal => Positions
        .Sum(p => p.Amount * p.Product.PriceTotal);
}

public enum OrderStatus
{
    Done,
    Delivery,
    Canceled,
    Burned
}
