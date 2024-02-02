using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand(int Id) : IRequest;

public class CancelOrderCommandHandler(
    IApplicationDbContext context,
    ICurrentUserService currentUserService)
    : IRequestHandler<CancelOrderCommand>
{
    private readonly IApplicationDbContext _context = context;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        Order entity = await _context.Orders
            .FindAsync([ request.Id ], cancellationToken)
            ?? throw new EntityNotFoundException("There is no entity with this Id in the database.");

        if(entity.OwnerId != _currentUserService.UserId)
        {
            throw new ForbiddenAccessException();
        }

        entity.Status = OrderStatus.Canceled;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
