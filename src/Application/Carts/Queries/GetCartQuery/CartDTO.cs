namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;

public class CartDTO
{
    public int Id { get; init; }
    public string ClientPhone { get; init; } = default!;
    public List<CartPositionDTO> Positions { get; init; } = [];
    public List<CartPositionDTO> AvailablePositions { get; init; } = default!;
    public decimal PriceTotal { get; init; }
    public bool IsAvailable { get; init; }
}