﻿using AutoMapper;

using MediatR;

using ShopOfPryaniks.Application.Common.Interfaces;

namespace ShopOfPryaniks.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery : IRequest<OrdersVM>;

public class GetOrdersQueryHandler(
    IPryanikiDbContext context, IMapper mapper)
    : IRequestHandler<GetOrdersQuery, OrdersVM>
{
    private readonly IPryanikiDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<OrdersVM> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return new OrdersVM
        {

        };
    }
}