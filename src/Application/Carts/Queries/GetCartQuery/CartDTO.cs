using AutoMapper;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;

public class CartDTO
{
    public int Id { get; init; }
    public List<CartPositionDTO> Positions { get; init; } = [];
    public List<CartPositionDTO> AvailablePositions { get; init; } = default!;
    public decimal PriceTotal { get; init; }
    public bool IsAvailable { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Cart, CartDTO>();
        }
    }
}