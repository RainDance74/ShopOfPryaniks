using MediatR;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.AddProduct;

public record AddProductCommand(int ProductId, int Amount) : IRequest;

public class AddProductCommandHandler(
    IPryanikiDbContext context)
    : IRequestHandler<AddProductCommand>
{
    private readonly IPryanikiDbContext _context = context;

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var cartWasCreated = false;

        Cart? cartEntity = await _context.Carts
            .FindAsync([ 1 ], cancellationToken); // TODO: Change 1 to current user id

        if(cartEntity == null)
        {
            (cartEntity, cartWasCreated) = (new Cart(), true);
        }

        Product productEntity = await _context.Products
            .FindAsync([ request.ProductId ], cancellationToken)
            ?? throw new EntityNotFoundException("There is no entity with this Id in the database.");

        cartEntity.Positions.Add(new CartPosition { Product = productEntity, Amount = request.Amount });

        if(cartWasCreated)
        {
            await _context.Carts.AddAsync(cartEntity, cancellationToken);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
