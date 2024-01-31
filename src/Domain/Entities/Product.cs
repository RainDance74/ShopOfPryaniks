using System.ComponentModel.DataAnnotations.Schema;

using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    private int _amount;
    public int Amount
    {
        get => _amount;
        set => _amount = Math.Max(value, 0);
    }
    public decimal Price { get; set; }
    private int _discount;
    public int Discount
    {
        get => _discount;
        set => _discount = Math.Clamp(value, 0, 100);
    }

    [NotMapped]
    public decimal PriceTotal
    {
        get
        {
            var sale = Price * ((decimal)Discount / 100);
            return Price - sale;
        }
    }
}
