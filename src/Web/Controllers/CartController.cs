using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetCartQuery()));

    [HttpPost("{positionId:int}")]
    public async Task<IResult> ChangePositionAmount(ISender sender, int positionId, [FromBody] ChangePositionAmountCommand command)
    {
        if(positionId != command.PositionId)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    [HttpDelete("{positionId:int}")]
    public async Task<IResult> Cancel(ISender sender, int positionId)
    {
        await sender.Send(new RemovePositionCommand(positionId));

        return Results.NoContent();
    }
}

