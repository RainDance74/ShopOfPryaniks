using System.ComponentModel.DataAnnotations.Schema;

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

    [NotMapped]
    public bool Finished => Status
        is OrderStatus.Done
        or OrderStatus.Canceled
        or OrderStatus.Burned;
}

public enum OrderStatus
{
    Done,
    Waiting,
    Delivery,
    Canceled,
    Burned
}
