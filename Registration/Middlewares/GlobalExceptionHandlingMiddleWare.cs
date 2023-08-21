using EfCore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Registration.Exceptions;
using System.Net;

namespace EfCore.Middlewares;

public class GlobalExceptionHandlingMiddleWare : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleWare> _logger;

    public GlobalExceptionHandlingMiddleWare(ILogger<GlobalExceptionHandlingMiddleWare> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            await HandleExceptionAsync(context, ex);
        }
        
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Type = exception.Source
        };

        switch (exception)
        {
            case BaseNotFoundException:
                problemDetails.Status =(int)HttpStatusCode.NotFound;
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case BaseInvalidDataException:
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
      
        return context.Response.WriteAsJsonAsync(problemDetails);
    }
}
