using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public int Amount { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }
}

public class CreateProductCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<CreateProductCommand, int>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Amount = request.Amount,
            Price = request.Price,
            Discount = request.Discount
        };

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
