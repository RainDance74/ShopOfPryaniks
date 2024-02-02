using AutoMapper;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class OrderDTO
{
    public int Id { get; init; }
    public List<OrderPositionDTO> Positions { get; init; } = [];
    public OrderStatus Status { get; init; }
    public decimal PriceTotal { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderDTO>();
        }
    }
}