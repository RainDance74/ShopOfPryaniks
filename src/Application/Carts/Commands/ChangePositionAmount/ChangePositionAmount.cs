using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Commands.ChangePositionAmount;

public record ChangePositionAmountCommand(int PositionId, int NewAmount) : IRequest;

public class ChangePositionAmountCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<ChangePositionAmountCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(ChangePositionAmountCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
