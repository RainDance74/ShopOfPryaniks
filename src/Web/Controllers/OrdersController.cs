using MediatR;

using Microsoft.AspNetCore.Mvc;

using ShopOfPryaniks.Application.Orders.Commands.CancelOrder;
using ShopOfPryaniks.Application.Orders.Commands.CreateOrder;
using ShopOfPryaniks.Application.Orders.Queries.GetOrders;

namespace ShopOfPryaniks.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(
    IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetOrdersQuery()));

    [HttpPost]
    public async Task<IResult> Create(ISender sender, [FromBody] CreateOrderCommand command) => Results.Ok(await sender.Send(command));

    [HttpPost("{id:int}")]
    public async Task<IResult> Cancel(ISender sender, int id)
    {
        await sender.Send(new CancelOrderCommand(id));

        return Results.NoContent();
    }
}
