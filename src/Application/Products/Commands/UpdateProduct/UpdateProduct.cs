using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string? Description { get; init; }
    public int Amount { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }
}

public class UpdateProductCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product entity = await _context.Products
            .FindAsync([ request.Id ], cancellationToken)
            ?? throw new EntityNotFoundException("There is no entity with this Id in the database.");

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Amount = request.Amount;
        entity.Price = request.Price;
        entity.Discount = request.Discount;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
