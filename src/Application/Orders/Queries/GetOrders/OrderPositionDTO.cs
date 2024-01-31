namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class OrderPositionDTO
{
    public int Id { get; init; }
    public ProductDTO Product { get; init; } = null!;
    public int Amount { get; init; }
}
