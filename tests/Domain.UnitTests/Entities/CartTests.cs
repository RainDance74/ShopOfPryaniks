using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.UnitTests.Entities;

[TestFixture]
public class CartTests
{
    [Test]
    public void ShouldCalculateTotalPriceFor1ProductInPosition()
    {
        var cart = new Cart();
        var product = new Product { Price = 150, Amount = 1};
        var position = new CartPosition { Product = product };
        cart.Positions.Add(position);

        var totalPrice = cart.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(150));
    }

    [Test]
    public void ShouldCalculateTotalPriceForMoreThan1ProductInPosition()
    {
        var cart = new Cart();
        var product = new Product { Price = 150, Amount = 5 };
        var position = new CartPosition { Product = product, Amount = 5 };
        cart.Positions.Add(position);

        var totalPrice = cart.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(750));
    }

    [Test]
    public void ShouldCalculateTotalPriceOnlyForAvailableAmountOfProducts()
    {
        var cart = new Cart();
        var product = new Product { Price = 150, Amount = 1 };
        var position = new CartPosition { Product = product, Amount = 5 };
        cart.Positions.Add(position);

        var totalPrice = cart.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(150));
    }

    [Test]
    public void ShouldCalculateTotalPriceWithDiscount()
    {
        var cart = new Cart();
        var product = new Product { Price = 100, Amount = 2, Discount = 10 };
        var position = new CartPosition { Product = product, Amount = 2 };
        cart.Positions.Add(position);

        var totalPrice = cart.PriceTotal;

        Assert.That(totalPrice, Is.EqualTo(180));
    }

    [Test]
    public void ShouldNotBeAvailableIfNoPositionsAreSpecified()
    {
        var cart = new Cart();

        var isAvailable = cart.IsAvailable;

        Assert.That(isAvailable, Is.False);
    }

    [Test]
    public void ShouldNotBeAvailableIfNoAvailablePositionsAreSpecified()
    {
        var cart = new Cart();
        var product = new Product { Price = 150 };
        var position = new CartPosition { Product = product, Amount = 5 };
        cart.Positions.Add(position);

        var isAvailable = cart.IsAvailable;

        Assert.That(isAvailable, Is.False);
    }
}
