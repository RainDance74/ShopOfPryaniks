using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<ProductsVM>;

public class GetProductsQueryHandler(
    IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductsQuery, ProductsVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductsVM> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return new ProductsVM
        {
            Products = await _context.Products
                .Where(p => p.IsAvailable)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}