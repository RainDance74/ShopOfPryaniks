using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Products.Queries.GetProducts;

public record GetAllProducts : IRequest<ProductsVM>;

public class GetAllProductsQueryHandler(
    IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAllProducts, ProductsVM>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductsVM> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        return new ProductsVM
        {
            Products = await _context.Products
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}