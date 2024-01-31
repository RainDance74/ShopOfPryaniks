using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.UnitTests.Entities;

[TestFixture]
public class ProductTests
{

    [Test]
    public void ShouldCalculateCorrectTotalPriceWhenDiscountIsNot0()
    {
        var product = new Product() { Discount = 10, Price = 100 };

        var totalPrice = product.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(90));
    }

    [Test]
    public void ShouldCalculateCorrectTotalPriceWhenDiscountIsOverA100()
    {
        var product = new Product() { Discount = 777, Price = 100 };

        var totalPrice = product.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(0));
    }

    [Test]
    public void ShouldCalculateCorrectTotalPriceWhenDiscountIs0()
    {
        var product = new Product() { Price = 100 };

        var totalPrice = product.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(100));
    }

    [Test]
    public void ShouldCalculateCorrectTotalPriceWhenDiscountIsLessThan0()
    {
        var product = new Product() { Discount = -10, Price = 100 };

        var totalPrice = product.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(100));
    }

    [Test]
    public void CouldNotHaveAmountLessThan0()
    {
        var product = new Product() { Amount = -1 };

        var amount = product.Amount;

        Assert.That(amount, Is.EqualTo(0));
    }
}
