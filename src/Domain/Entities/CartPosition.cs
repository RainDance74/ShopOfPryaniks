using System.ComponentModel.DataAnnotations.Schema;

using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;

public class CartPosition : BasePosition
{
    [NotMapped]
    public int AvailableAmount => Math.Min(Product.Amount, Amount);
}
