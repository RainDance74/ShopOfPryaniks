using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.ChangePositionAmount;

public record ChangePositionAmountCommand(int PositionId, int NewAmount) : IRequest;

public class ChangePositionAmountCommandHandler(
    IApplicationDbContext context,
    ICurrentUserService currentUserService)
    : IRequestHandler<ChangePositionAmountCommand>
{
    private readonly IApplicationDbContext _context = context;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task Handle(ChangePositionAmountCommand request, CancellationToken cancellationToken)
    {
        Cart cartEntity = await _context.Carts
            .Where(c => c.OwnerId == _currentUserService.UserId)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("There is no cart entity with this Id in the database.");

        CartPosition targetPosition = cartEntity.Positions
            .FirstOrDefault(position => position.Id == request.PositionId)
            ?? throw new EntityNotFoundException("There is no position entity with this Id in the database.");

        targetPosition.Amount = request.NewAmount;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
