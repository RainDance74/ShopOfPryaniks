using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.UnitTests.Entities;

[TestFixture]
public class CartPositionTests
{
    [Test]
    public void PositionAmountCanNotBeLessThanOne()
    {
        var position = new CartPosition { Product = new(), Amount = -1 };

        var amount = position.Amount;

        Assert.That(amount, Is.EqualTo(1));
    }

    [Test]
    public void AvailablePositionAmountCanNotBeMoreThanAvailableProductsAmount()
    {
        var position = new CartPosition { Product = new Product { Amount = 5 }, Amount = 255 };

        var amount = position.AvailableAmount;

        Assert.That(amount, Is.EqualTo(5));
    }
}
