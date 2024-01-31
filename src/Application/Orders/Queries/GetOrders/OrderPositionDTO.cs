using AutoMapper;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public class OrderPositionDTO
{
    public int Id { get; init; }
    public ProductDTO Product { get; init; } = null!;
    public int Amount { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OrderPosition, OrderPositionDTO>();
        }
    }
}
