using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.RemovePosition;

public record RemovePositionCommand(int PositionId) : IRequest;

public class RemovePositionCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<RemovePositionCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(RemovePositionCommand request, CancellationToken cancellationToken)
    {
        Cart cartEntity = await _context.Carts
            .FindAsync([ 1 ], cancellationToken) // TODO: Change 1 to current user id
            ?? throw new EntityNotFoundException("There is no cart entity with this Id in the database.");

        CartPosition targetPosition = cartEntity.Positions
            .FirstOrDefault(position => position.Id == request.PositionId)
            ?? throw new EntityNotFoundException("There is no position entity with this Id in the database.");

        _context.Positions.Remove(targetPosition);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
