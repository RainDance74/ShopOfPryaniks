using System.Net;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ShopOfPryaniks.Application.Carts.Commands.AddProduct;
using ShopOfPryaniks.Application.Carts.Commands.ChangePositionAmount;
using ShopOfPryaniks.Application.Carts.Commands.RemovePosition;
using ShopOfPryaniks.Application.Carts.Queries.GetCartQuery;

namespace ShopOfPryaniks.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartController(
    IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Gets the user cart
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CartVM))]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetCartQuery()));

    /// <summary>
    /// Adds a product to user cart
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     
    ///     POST /api/Cart/addProduct/1
    ///     {
    ///         "productId": 1,
    ///         "amount": 5
    ///     }
    /// 
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="productId">Product Id to add</param>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <response code="400">If the product Id is not the same for http address and body</response>
    /// <response code="404">If there is no product with this Id</response>
    [HttpPost("addProduct/{productId:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> AddProduct(ISender sender, int productId, [FromBody] AddProductCommand command)
    {
        if(productId != command.ProductId)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    /// <summary>
    /// Changes the position amount in user cart
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     
    ///     POST /api/Cart/editPosition/1
    ///     {
    ///         "positionId": 1,
    ///         "newAmount": 10
    ///     }
    /// 
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="positionId">Position Id to change</param>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <response code="400">If the position Id is not the same for http address and body</response>
    /// <response code="404">If there is no position with this Id</response>
    [HttpPost("editPosition/{positionId:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> ChangePositionAmount(ISender sender, int positionId, [FromBody] ChangePositionAmountCommand command)
    {
        if(positionId != command.PositionId)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    /// <summary>
    /// Remove position from user cart
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="positionId">Position Id to delete</param>
    /// <returns></returns>
    /// <response code="404">If there is no position with this Id</response>
    [HttpDelete("{positionId:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Cancel(ISender sender, int positionId)
    {
        await sender.Send(new RemovePositionCommand(positionId));

        return Results.NoContent();
    }
}

