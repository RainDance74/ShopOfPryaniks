using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand(int Id) : IRequest;

public class CancelOrderCommandHandler(
    IPryanikiDbContext context) : IRequestHandler<CancelOrderCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
