using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.UnitTests.Entities;

[TestFixture]
public class OrderTests
{
    [Test]
    public void ShouldCalculateTotalPriceFor1ProductInPosition()
    {
        var order = new Order();
        var product = new Product { Price = 150, Amount = 1};
        var position = new OrderPosition { Product = product };
        order.Positions.Add(position);

        var totalPrice = order.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(150));
    }

    [Test]
    public void ShouldCalculateTotalPriceForMoreThan1ProductInPosition()
    {
        var order = new Order();
        var product = new Product { Price = 150, Amount = 5 };
        var position = new OrderPosition { Product = product, Amount = 5 };
        order.Positions.Add(position);

        var totalPrice = order.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(750));
    }
}