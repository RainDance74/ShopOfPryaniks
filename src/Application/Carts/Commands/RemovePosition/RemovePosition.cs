using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.RemovePosition;

public record RemovePositionCommand(int PositionId) : IRequest;

public class RemovePositionCommandHandler(
    IApplicationDbContext context,
    ICurrentUserService currentUserService)
    : IRequestHandler<RemovePositionCommand>
{
    private readonly IApplicationDbContext _context = context;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task Handle(RemovePositionCommand request, CancellationToken cancellationToken)
    {
        Cart cartEntity = await _context.Carts
            .Include(c => c.Positions)
            .Where(c => c.OwnerId == _currentUserService.UserId)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("There is no cart entity with this Id in the database.");

        CartPosition targetPosition = cartEntity.Positions
            .FirstOrDefault(position => position.Id == request.PositionId)
            ?? throw new EntityNotFoundException("There is no position entity with this Id in the database.");

        _context.Positions.Remove(targetPosition);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
