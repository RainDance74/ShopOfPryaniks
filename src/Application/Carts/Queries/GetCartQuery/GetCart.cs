using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;
public record GetCartQuery : IRequest<CartVM>;

public class GetCartQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICurrentUserService currentUserService)
    : IRequestHandler<GetCartQuery, CartVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<CartVM> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return new CartVM
        {
            Cart = _mapper.Map<CartDTO>(
                await _context.Carts
                .FirstOrDefaultAsync(c => c.OwnerId == _currentUserService.UserId, cancellationToken))
        };
    }
}
