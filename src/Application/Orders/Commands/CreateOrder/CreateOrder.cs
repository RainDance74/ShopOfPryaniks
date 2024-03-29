﻿using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<int>;

public class CreateOrderCommandHandler(
    IApplicationDbContext context,
    ICurrentUserService currentUserService)
    : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IApplicationDbContext _context = context;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Cart? cartEntity = await _context.Carts
            .Include(c => c.Positions)
            .ThenInclude(p => p.Product)
            .Where(c => c.OwnerId == _currentUserService.UserId)
            .SingleOrDefaultAsync(cancellationToken);

        if(cartEntity is null || !cartEntity.IsAvailable)
        {
            throw new InvalidOperationException("There is no any products in the cart.");
        }

        var orderEntity = new Order
        {
            OwnerId = _currentUserService.UserId!,
            Status = OrderStatus.Waiting
        };

        orderEntity.Positions.AddRange(cartEntity.AvailablePositions
            .Select(p => new OrderPosition
            {
                Product = p.Product,
                Amount = p.AvailableAmount
            })
        );

        orderEntity.CalculatePriceTotal();

        // Remove products amount from db:
        IEnumerable<Tuple<Product, int>> products = _context.Products
            .AsEnumerable()
            .Where(product => cartEntity.Positions.Any(position => position.Product.Id == product.Id))
            .Select(product => new Tuple<Product, int>(product, cartEntity.Positions.First(p => p.Product.Id == product.Id).AvailableAmount));

        foreach(Tuple<Product, int>? product in products)
        {
            product.Item1.Amount -= product.Item2;
        }

        _context.Orders.Add(orderEntity);

        cartEntity.Clean();

        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(orderEntity.Id);
    }
}