using Microsoft.AspNetCore.Mvc.Filters;

namespace FoundationService.API.Filters;

public class AuditLoggingAttribute : ActionFilterAttribute
{
    private readonly ILogger<AuditLoggingAttribute> _logger;

    public AuditLoggingAttribute(ILogger<AuditLoggingAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        _logger.LogInformation($"Date: {DateTime.UtcNow}\n\t" +
            $"Method: { request.Method }\n\t" +
            $"Origin: { request.Headers["origin"] }\n\t" +
            $"Path: {request.Path.Value}\n\t" +
            $"From: { context.HttpContext.User.Identity.Name }\n");

        base.OnActionExecuting(context);
    }
}
