using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product entity = await _context.Products
            .Where(product => product.Id  == request.Id)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("There is no entity with this Id in the database.");

        _context.Products.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}