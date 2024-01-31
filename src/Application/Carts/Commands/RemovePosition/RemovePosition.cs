using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Commands.RemovePosition;

public record RemovePositionCommand(int PositionId) : IRequest;

public class RemovePositionCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<RemovePositionCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(RemovePositionCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
