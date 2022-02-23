using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace API.Middleware;

internal class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        if (exception is ArgumentException || exception is FormatException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (exception is InvalidOperationException
            || exception is DbUpdateException
            || exception is DbUpdateConcurrencyException
            || exception is OperationCanceledException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
        }
        
        var result = JsonSerializer.Serialize(new
        {
            message = exception.Message,
            innerExceptionMessage = exception.InnerException?.Message
        });
       
        await context.Response.WriteAsync(result);
    }
}
