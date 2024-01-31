namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class ProductDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public int Amount { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }

    public decimal PriceTotal { get; init; }
}
