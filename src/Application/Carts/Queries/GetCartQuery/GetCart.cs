using AutoMapper;

using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;
public record GetCartQuery : IRequest<CartVM>;

public class GetCartQueryHandler(
    IPryanikiDbContext context, IMapper mapper)
    : IRequestHandler<GetCartQuery, CartVM>
{
    private readonly IPryanikiDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CartVM> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return new CartVM
        {

        };
    }
}
