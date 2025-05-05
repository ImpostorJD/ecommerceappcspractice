using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Shared.Middleware;

public class ExceptionsHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsHandler> _logger;

    public ExceptionsHandler(RequestDelegate next, ILogger<ExceptionsHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

     public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught by middleware");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var (statusCode, message) = ex switch
        {
            BadRequestException => ((int)HttpStatusCode.BadRequest, ex.Message),
            NotFoundException => ((int)HttpStatusCode.NotFound, ex.Message),
            UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized, "Unauthorized"),
            _ => ((int)HttpStatusCode.InternalServerError, "An unexpected error occurred")
        };

        response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new
        {
            status = statusCode,
            error = message
        });

        return response.WriteAsync(result);
    }
}
