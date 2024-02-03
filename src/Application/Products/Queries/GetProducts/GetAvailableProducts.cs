using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Queries.GetProducts;

public record GetAvailableProducts : IRequest<ProductsVM>;

public class GetAvailableProductsQueryHandler(
    IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAvailableProducts, ProductsVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductsVM> Handle(GetAvailableProducts request, CancellationToken cancellationToken)
    {
        return new ProductsVM
        {
            Products = await _context.Products
                .Where(p => p.Amount > 0)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}
