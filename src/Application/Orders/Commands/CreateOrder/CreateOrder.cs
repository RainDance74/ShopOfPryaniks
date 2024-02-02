using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Exceptions;
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
        Cart cartEntity = await _context.Carts
            .Include(c => c.Positions)
            .ThenInclude(p => p.Product)
            .Where(c => c.OwnerId == _currentUserService.UserId)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("There is no cart entity with this Id in the database.");

        if(!cartEntity.IsAvailable)
        {
            throw new InvalidOperationException("There is no any products in the cart.");
        }

        var orderEntity = new Order
        {
            OwnerId = _currentUserService.UserId!,
            Status = OrderStatus.Delivery
        };

        orderEntity.Positions.AddRange(cartEntity.Positions
            .Select(p => new OrderPosition
            {
                Product = p.Product,
                Amount = p.Amount
            })
        );

        _context.Orders.Add(orderEntity);

        cartEntity.Clean();

        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(orderEntity.Id);
    }
}