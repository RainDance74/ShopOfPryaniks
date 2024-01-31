using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Commands.AddProduct;

public record AddProductCommand(int ProductId, int Amount) : IRequest;

public class AddProductCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<AddProductCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
