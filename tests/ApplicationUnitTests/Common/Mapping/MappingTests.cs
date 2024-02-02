using System.Reflection;
using System.Runtime.Serialization;

using AutoMapper;

using ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Application.Orders.Queries.GetOrders;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.UnitTests.Common.Mapping;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration() => _configuration.AssertConfigurationIsValid();

    [Test]
    public void ShouldMapOrderWithOrderPositionToOrderDTOWithPositionDTO()
    {
        // Arrange
        var order = new Order();
        var orderProduct = new Product { Amount = 1, Name = "Pryanik" };
        var orderPosition = new OrderPosition { Product = orderProduct };
        order.Positions.Add(orderPosition);

        // Act
        OrderDTO orderEntity = _mapper.Map<Order, OrderDTO>(order);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(orderEntity.Positions.First().Product.Amount, Is.EqualTo(orderProduct.Amount));
            Assert.That(orderEntity.Positions.First().Product.Name, Is.EqualTo(orderProduct.Name));
        });
    }

    [Test]
    public void ShouldMapCartWithCartPositionToCartEntityWithPositionEntity()
    {
        // Arrange
        var cart = new Cart();
        var cartProduct = new Product { Amount = 1, Name = "Pryanik" };
        var cartPosition = new CartPosition { Product = cartProduct };
        cart.Positions.Add(cartPosition);

        // Act
        CartDTO cartEntity = _mapper.Map<Cart, CartDTO>(cart);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(cartEntity.Positions.First().Product.Amount, Is.EqualTo(cartProduct.Amount));
            Assert.That(cartEntity.Positions.First().Product.Name, Is.EqualTo(cartProduct.Name));
        });
    }

    [Test]
    [TestCase(typeof(Product), typeof(Products.Queries.GetProducts.ProductDTO))]
    [TestCase(typeof(Product), typeof(Orders.Queries.GetOrders.ProductDTO))]
    [TestCase(typeof(Product), typeof(Carts.Queries.GetCartQuery.ProductDTO))]
    [TestCase(typeof(OrderPosition), typeof(OrderPositionDTO))]
    [TestCase(typeof(CartPosition), typeof(CartPositionDTO))]
    [TestCase(typeof(Order), typeof(OrderDTO))]
    [TestCase(typeof(Cart), typeof(CartDTO))]
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