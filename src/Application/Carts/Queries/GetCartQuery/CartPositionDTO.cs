namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;

public class CartPositionDTO
{
    public int Id { get; init; }
    public ProductDTO Product { get; init; } = null!;
    public int Amount { get; init; }
    public int AvailableAmount { get; init; }
}
