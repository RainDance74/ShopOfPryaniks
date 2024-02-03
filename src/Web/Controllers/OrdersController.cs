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

    /// <summary>
    /// Gets the list of orders for current user
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrdersVM))]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetOrders()));

    /// <summary>
    /// Creates a new order based on available products in user cart
    /// </summary>
    /// <returns></returns>
    /// <response code="400">If there is no any products in user cart</response>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IResult> Create(ISender sender) => Results.Ok(await sender.Send(new CreateOrderCommand()));

    /// <summary>
    /// Cancels order for user
    /// </summary>
    /// <returns></returns>
    /// <response code="400">If order status don't need to be changed</response>
    /// <response code="403">If user is not owning the order</response>
    /// <response code="404">If order was not found</response>
    [HttpPost("cancel/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Cancel(ISender sender, int id)
    {
        await sender.Send(new CancelOrderCommand(id));

        return Results.NoContent();
    }
}
