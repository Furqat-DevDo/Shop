using EfCore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EfCore.Attributes;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{

    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,
        };

        switch (exception)
        {
            case BaseNotFoundException :
                problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
                problemDetails.Status = (int)HttpStatusCode.NotFound;
                problemDetails.Title = exception.Message;
                break;

            default:
                break;
        }

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
