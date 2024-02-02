using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class Order : BaseEntity
{
    public string OwnerId { get; init; } = default!;
    public List<OrderPosition> Positions { get; } = [];
    public OrderStatus Status { get; set; }
    public decimal PriceTotal { get; set; }

    public decimal CalculatePriceTotal() =>
        PriceTotal = Positions
        .Sum(p => p.Amount * p.Product.PriceTotal);
}

public enum OrderStatus
{
    Done,
    Delivery,
    Canceled,
    Burned
}
