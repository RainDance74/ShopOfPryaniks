using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<int>;

public class CreateOrderCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find the cart by user ID
        // TODO: Check if available to buy

        var orderEntity = new Order
        {
            // TODO: Turn the cart to Order
        };

        // TODO: Clean the cart

        return await Task.FromResult(-1);
    }
}