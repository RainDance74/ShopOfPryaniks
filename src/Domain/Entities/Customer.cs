using ShopOfPryaniks.Domain.Common;

namespace ShopOfPryaniks.Domain.Entities;
public class Customer : BaseUser
{
    public string PhoneNumber { get; set; } = default!;
}