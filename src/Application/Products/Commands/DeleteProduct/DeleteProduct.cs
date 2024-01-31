using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}