using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;
public record GetCartQuery : IRequest<CartVM>;

public class GetCartQueryHandler(
    IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCartQuery, CartVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CartVM> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return new CartVM
        {
            Cart = _mapper.Map<CartDTO>(
                await _context.Carts
                // Find first of default by owner Id
                .FirstOrDefaultAsync(cancellationToken))
        };
    }
}
