using System.Reflection;
using System.Runtime.Serialization;

using AutoMapper;

using ShopOfPryaniks.Domain.Entities;
using ShopOfPryaniks.Persistence.Entities;

namespace ShopOfPryaniks.Persistence.UnitTests.Mapping;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(OrderEntity))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration() => _configuration.AssertConfigurationIsValid();

    [Test]
    public void ShouldMapOrderWithOrderPositionToOrderEntityWithPositionEntity()
    {
        // Arrange
        var order = new Order
        {
            ClientPhone = "88005553535"
        };
        var orderProduct = new Product { Amount = 1, Name = "Pryanik" };
        var orderPosition = new OrderPosition { Product = orderProduct };
        order.Positions.Add(orderPosition);

        var expectedOrderEntity = new OrderEntity
        {
            ClientPhone = order.ClientPhone
        };
        var expectedProductEntity = new ProductEntity
        {
            Amount = orderProduct.Amount,
            Name = orderProduct.Name
        };
        var expectedPositionEntity = new PositionEntity
        {
            Product = expectedProductEntity
        };

        // Act
        OrderEntity orderEntity = _mapper.Map<Order, OrderEntity>(order);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(orderEntity.ClientPhone, Is.EqualTo(expectedOrderEntity.ClientPhone));
            Assert.That(orderEntity.Positions.First().Product.Amount, Is.EqualTo(expectedProductEntity.Amount));
            Assert.That(orderEntity.Positions.First().Product.Name, Is.EqualTo(expectedProductEntity.Name));
        });
    }

    [Test]
    public void ShouldMapOrderEntityWithProductEntityToOrderWithProduct()
    {
        // Arrange
        var orderEntity = new OrderEntity
        {
            ClientPhone = "88005553535"
        };
        var orderProductEntity = new ProductEntity { Amount = 1, Name = "Pryanik" };
        var positionEntity = new PositionEntity { Product = orderProductEntity };
        orderEntity.Positions.Add(positionEntity);

        var expectedOrder = new Order
        {
            ClientPhone = orderEntity.ClientPhone
        };
        var expectedProduct = new Product
        {
            Amount = orderProductEntity.Amount,
            Name = orderProductEntity.Name
        };

        // Act
        Order order = _mapper.Map<OrderEntity, Order>(orderEntity);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(order.ClientPhone, Is.EqualTo(expectedOrder.ClientPhone));
            Assert.That(order.Positions.First().Product.Amount, Is.EqualTo(expectedProduct.Amount));
            Assert.That(order.Positions.First().Product.Name, Is.EqualTo(expectedProduct.Name));
        });
    }

    [Test]
    public void ShouldMapCartWithCartPositionToCartEntityWithPositionEntity()
    {
        // Arrange
        var cart = new Cart
        {
            ClientPhone = "88005553535"
        };
        var cartProduct = new Product { Amount = 1, Name = "Pryanik" };
        var cartPosition = new CartPosition { Product = cartProduct };
        cart.Positions.Add(cartPosition);

        var expectedCartEntity = new CartEntity
        {
            ClientPhone = cart.ClientPhone
        };
        var expectedProductEntity = new ProductEntity
        {
            Amount = cartProduct.Amount,
            Name = cartProduct.Name
        };
        var expectedPositionEntity = new PositionEntity
        {
            Product = expectedProductEntity
        };

        // Act
        CartEntity cartEntity = _mapper.Map<Cart, CartEntity>(cart);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(cartEntity.ClientPhone, Is.EqualTo(expectedCartEntity.ClientPhone));
            Assert.That(cartEntity.Positions.First().Product.Amount, Is.EqualTo(expectedProductEntity.Amount));
            Assert.That(cartEntity.Positions.First().Product.Name, Is.EqualTo(expectedProductEntity.Name));
        });
    }

    [Test]
    public void ShouldMapCartEntityWithProductEntityToCartWithProduct()
    {
        // Arrange
        var cartEntity = new CartEntity
        {
            ClientPhone = "88005553535"
        };
        var cartProductEntity = new ProductEntity { Amount = 1, Name = "Pryanik" };
        var positionEntity = new PositionEntity { Product = cartProductEntity };
        cartEntity.Positions.Add(positionEntity);

        var expectedCart = new Cart
        {
            ClientPhone = cartEntity.ClientPhone
        };
        var expectedProduct = new Product
        {
            Amount = cartProductEntity.Amount,
            Name = cartProductEntity.Name
        };

        // Act
        Cart cart = _mapper.Map<CartEntity, Cart>(cartEntity);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(cart.ClientPhone, Is.EqualTo(expectedCart.ClientPhone));
            Assert.That(cart.Positions.First().Product.Amount, Is.EqualTo(expectedProduct.Amount));
            Assert.That(cart.Positions.First().Product.Name, Is.EqualTo(expectedProduct.Name));
        });
    }

    [Test]
    [TestCase(typeof(Order), typeof(OrderEntity))]
    [TestCase(typeof(OrderEntity), typeof(Order))]
    [TestCase(typeof(Cart), typeof(CartEntity))]
    [TestCase(typeof(CartEntity), typeof(Cart))]
    [TestCase(typeof(OrderPosition), typeof(PositionEntity))]
    [TestCase(typeof(PositionEntity), typeof(OrderPosition))]
    [TestCase(typeof(Product), typeof(ProductEntity))]
    [TestCase(typeof(ProductEntity), typeof(Product))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type)
    {
        if(type.GetConstructor(Type.EmptyTypes) != null)
        {
            return Activator.CreateInstance(type)!;
        }

        // Type without parameterless constructor
        // TODO: Figure out an alternative approach to the now obsolete `FormatterServices.GetUninitializedObject` method.
#pragma warning disable SYSLIB0050 // Type or member is obsolete
        return FormatterServices.GetUninitializedObject(type);
#pragma warning restore SYSLIB0050 // Type or member is obsolete
    }
}
