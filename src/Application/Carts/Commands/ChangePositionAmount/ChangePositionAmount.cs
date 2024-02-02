using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.ChangePositionAmount;

public record ChangePositionAmountCommand(int PositionId, int NewAmount) : IRequest;

public class ChangePositionAmountCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<ChangePositionAmountCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(ChangePositionAmountCommand request, CancellationToken cancellationToken)
    {
        Cart cartEntity = await _context.Carts
            .FindAsync([ 1 ], cancellationToken) // TODO: Change 1 to current user id
            ?? throw new EntityNotFoundException("There is no cart entity with this Id in the database.");

        CartPosition targetPosition = cartEntity.Positions
            .FirstOrDefault(position => position.Id == request.PositionId)
            ?? throw new EntityNotFoundException("There is no position entity with this Id in the database.");

        targetPosition.Amount = request.NewAmount;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
