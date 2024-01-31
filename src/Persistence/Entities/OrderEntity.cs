using AutoMapper;

using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Entities;

public class OrderEntity : BaseEntity
{
    public string ClientPhone { get; set; } = default!;
    public OrderEntityStatus Status { get; set; }
    public List<PositionEntity> Positions { get; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderEntity>();
            CreateMap<OrderEntity, Order>();
        }
    }
}

public enum OrderEntityStatus
{
    Done,
    Delivery,
    Canceled,
    Burned
}
