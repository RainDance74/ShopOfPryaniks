using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class OrderDTO
{
    public int Id { get; init; }
    public string ClientPhone { get; init; } = default!;
    public List<OrderPositionDTO> Positions { get; init; } = [];
    public OrderStatus Status { get; init; }
    public decimal PriceTotal { get; init; }
}