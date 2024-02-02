using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public record GetOrders : IRequest<OrdersVM>;

public class GetOrdersQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICurrentUserService currentUserService)
    : IRequestHandler<GetOrders, OrdersVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<OrdersVM> Handle(GetOrders request, CancellationToken cancellationToken)
    {
        return new OrdersVM
        {
            Orders = await _context.Orders
                .Include(o => o.Positions)
                .ThenInclude(p => p.Product)
                .Where(o => o.OwnerId == _currentUserService.UserId)
                .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}
