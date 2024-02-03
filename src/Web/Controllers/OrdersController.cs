using System.Net;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ShopOfPryaniks.Application.Orders.Commands.CancelOrder;
using ShopOfPryaniks.Application.Orders.Commands.CreateOrder;
using ShopOfPryaniks.Application.Orders.Queries.GetOrders;

namespace ShopOfPryaniks.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController(
    IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrdersVM))]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetOrders()));

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IResult> Create(ISender sender) => Results.Ok(await sender.Send(new CreateOrderCommand()));

    [HttpPost("cancel/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Cancel(ISender sender, int id)
    {
        await sender.Send(new CancelOrderCommand(id));

        return Results.NoContent();
    }
}
