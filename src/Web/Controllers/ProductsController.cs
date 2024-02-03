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

    /// <summary>
    /// Gets the list of all products
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductsVM))]
    public async Task<IResult> GetAll(ISender sender) => Results.Ok(await sender.Send(new GetAllProducts()));

    /// <summary>
    /// Gets the list of available products
    /// </summary>
    /// <returns></returns>
    [HttpGet("available")]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductsVM))]
    public async Task<IResult> GetAvailable(ISender sender) => Results.Ok(await sender.Send(new GetAvailableProducts()));

    /// <summary>
    /// Creates a product
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     
    ///     POST /api/Products
    ///     {
    ///         "name": "Pryanik",
    ///         "description": "A very tasty pryanik",
    ///         "amount": 60,
    ///         "price": 500,
    ///         "discount": 10
    ///     }
    /// 
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="command">Product to create</param>
    /// <returns>A newly created Product Id</returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
    public async Task<IResult> Create(ISender sender, [FromBody] CreateProductCommand command) => Results.Ok(await sender.Send(command));

    /// <summary>
    /// Updates a product
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     
    ///     PUT /api/Products/1
    ///     {
    ///         "id": 1,
    ///         "name": "Pryanik",
    ///         "description": "A very tasty pryanik",
    ///         "amount": 60,
    ///         "price": 500,
    ///         "discount": 10
    ///     }
    /// 
    /// </remarks>
    /// <param name="sender"></param>
    /// <param name="id">An Id of item to update</param>
    /// <param name="command">Product to update</param>
    /// <returns></returns>
    /// <response code="400">If the product Id is not the same for http address and body</response>
    /// <response code="404">If there is no product with this Id</response>
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

    /// <summary>
    /// Deletes a product
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="id">An Id of item to delete</param>
    /// <returns></returns>
    /// <response code="404">If there is no product with this Id</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IResult> Delete(ISender sender, int id)
    {
        await sender.Send(new DeleteProductCommand(id));

        return Results.NoContent();
    }
}
