namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class OrdersVM
{
    public IReadOnlyCollection<OrderDTO> Orders { get; init; } = [];
}
