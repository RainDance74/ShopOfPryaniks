using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class Cart : BaseEntity
{
    public string ClientPhone { get; set; } = default!;
    public List<CartPosition> Positions { get; } = [];
    public List<CartPosition> AvailablePositions
    {
        get => Positions
            .Where(p => p.AvailableAmount != 0)
            .ToList();
    }
    public decimal PriceTotal => AvailablePositions
        .Sum(p => p.AvailableAmount * p.Product.PriceTotal);
    public bool IsAvailable => AvailablePositions.Count != 0;
}
