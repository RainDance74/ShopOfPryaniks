using AutoMapper;

using ShopOfPryaniks.Domain.Common;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Entities;
public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    private int _discount;
    public int Discount
    {
        get => _discount;
        set => _discount = Math.Clamp(value, 0, 100);
    }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductEntity, Product>();
        }
    }
}