using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<ProductsVM>;

public class GetProductsQueryHandler(
    IPryanikiDbContext context, IMapper mapper)
    : IRequestHandler<GetProductsQuery, ProductsVM>
{
    private readonly IPryanikiDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductsVM> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return new ProductsVM
        {
            Products = await _context.Products
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}