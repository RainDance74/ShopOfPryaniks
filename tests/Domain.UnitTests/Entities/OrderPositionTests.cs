using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Domain.UnitTests.Entities;

[TestFixture]
public class OrderPositionTests
{
    [Test]
    public void PositionAmountCanNotBeLessThanOne()
    {
        var position = new OrderPosition { Product = new(), Amount = -1 };

        var amount = position.Amount;

        Assert.That(amount, Is.EqualTo(1));
    }
}
