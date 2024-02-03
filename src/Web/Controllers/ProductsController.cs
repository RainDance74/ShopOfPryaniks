using System.Net;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ShopOfPryaniks.Application.Products.Commands.CreateProduct;
using ShopOfPryaniks.Application.Products.Commands.DeleteProduct;
using ShopOfPryaniks.Application.Products.Commands.UpdateProduct;
using ShopOfPryaniks.Application.Products.Queries.GetProducts;
using ShopOfPryaniks.Domain.Constants;

namespace ShopOfPryaniks.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = Roles.Administrator)]
public class ProductsController(
    IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductsVM))]
    public async Task<IResult> Get(ISender sender) => Results.Ok(await sender.Send(new GetProductsQuery()));

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    public async Task<IResult> Create(ISender sender, [FromBody] CreateProductCommand command) => Results.Ok(await sender.Send(command));

    [HttpPut("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Update(ISender sender, int id, [FromBody] UpdateProductCommand command)
    {
        if(id != command.Id)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Delete(ISender sender, int id)
    {
        await sender.Send(new DeleteProductCommand(id));

        return Results.NoContent();
    }
}
