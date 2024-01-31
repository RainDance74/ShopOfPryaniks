using AutoMapper;

using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Entities;
public class CartEntity : BaseEntity
{
    public string ClientPhone { get; set; } = default!;
    public List<PositionEntity> Positions { get; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Cart, CartEntity>();
            CreateMap<CartEntity, Cart>()
                .ForMember(m => m.AvailablePositions, options => options.Ignore());
        }
    }
}