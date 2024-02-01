using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand(int Id) : IRequest;

public class CancelOrderCommandHandler(
    IPryanikiDbContext context) : IRequestHandler<CancelOrderCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        Order entity = await _context.Orders
            .FindAsync([ request.Id ], cancellationToken)
            ?? throw new EntityNotFoundException("There is no entity with this Id in the database.");

        entity.Status = OrderStatus.Canceled;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
