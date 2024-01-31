using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<int>;

public class CreateOrderCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IPryanikiDbContext _context = context;

    // TODO: Clean the cart
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
