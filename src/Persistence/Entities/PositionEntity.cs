using AutoMapper;

using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Entities;
public class PositionEntity : BaseEntity
{
    public ProductEntity Product { get; set; } = null!;
    public int Amount { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PositionEntity, CartPosition>()
                .ForMember(m => m.AvailableAmount, options => options.Ignore());
            CreateMap<PositionEntity, OrderPosition>();
            CreateMap<CartPosition, PositionEntity>();
            CreateMap<OrderPosition, PositionEntity>();
        }
    }
}
