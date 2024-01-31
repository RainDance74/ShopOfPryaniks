using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public int Amount { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }
}

public class UpdateProductCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
