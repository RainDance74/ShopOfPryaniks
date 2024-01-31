using AutoMapper;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;

public class CartPositionDTO
{
    public int Id { get; init; }
    public ProductDTO Product { get; init; } = null!;
    public int Amount { get; init; }
    public int AvailableAmount { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CartPosition, CartPositionDTO>()
                .ForMember(m => m.AvailableAmount, options => options.MapFrom(m => m.AvailableAmount));
        }
    }
}
