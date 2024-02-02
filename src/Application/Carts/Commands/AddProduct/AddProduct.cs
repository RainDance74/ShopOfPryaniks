using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Exceptions;
using ShopOfPryaniks.Application.Common.Interfaces;
using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Application.Carts.Commands.AddProduct;

public record AddProductCommand(int ProductId, int Amount) : IRequest;

public class AddProductCommandHandler(
    IApplicationDbContext context,
    ICurrentUserService currentUserService)
    : IRequestHandler<AddProductCommand>
{
    private readonly IApplicationDbContext _context = context;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var cartWasCreated = false;

        Cart? cartEntity = await _context.Carts
            .Where(c => c.OwnerId == _currentUserService.UserId)
            .SingleOrDefaultAsync(cancellationToken);

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
            cartEntity.OwnerId = _currentUserService.UserId!;
            await _context.Carts.AddAsync(cartEntity, cancellationToken);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
