using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using ShopOfPryaniks.Application.Common.Exceptions;

namespace ShopOfPryaniks.Web.Infrastructure;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;
    private readonly IHostEnvironment _hostEnvironment;

    public CustomExceptionHandler(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;

        // Register known exception types and handlers.
        _exceptionHandlers = new()
            {
                { typeof(EntityNotFoundException), HandleEntityNotFoundException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(InvalidOperationException), HandleInvalidOperationException }
            };
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        Type exceptionType = exception.GetType();

        if(_exceptionHandlers.TryGetValue(exceptionType, out Func<HttpContext, Exception, Task>? handler))
        {
            await handler.Invoke(httpContext, exception);
            return true;
        }

        return false;
    }

    private async Task HandleEntityNotFoundException(HttpContext httpContext, Exception ex)
    {
        var exception = ex as EntityNotFoundException;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception?.Message
        });
    }

    private async Task HandleForbiddenAccessException(HttpContext httpContext, Exception ex)
    {
        if(_hostEnvironment.EnvironmentName == Environments.Development)
        {
            var exception = (ForbiddenAccessException)ex;

            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                Detail = exception.Message
            });
        }
        else
        {
            await HandleEntityNotFoundException(httpContext, ex);
        }
    }

    private async Task HandleInvalidOperationException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Bad request",
            Detail = ex.Message
        });
    }
}
