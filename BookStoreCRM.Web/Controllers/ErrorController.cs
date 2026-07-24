using BookStoreCRM.BLL.Exceptions;
using BookStoreCRM.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Controllers;

[AllowAnonymous]
public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [Route("/Error")]
    public IActionResult Error()
    {
        var exceptionFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        var exception = exceptionFeature?.Error;

        if (exception is not null)
        {
            _logger.LogError(
                exception,
                "Unhandled exception while processing {Path}",
                exceptionFeature?.Path);
        }

        var model = CreateErrorModel(exception);

        Response.StatusCode = model.StatusCode;

        return View(model);
    }

    [Route("/Error/{statusCode:int}")]
    public IActionResult StatusCodeError(int statusCode)
    {
        var model = statusCode switch
        {
            StatusCodes.Status404NotFound => new ErrorViewModel
            {
                StatusCode = statusCode,
                Title = "Page not found",
                Message = "The requested page could not be found."
            },

            StatusCodes.Status403Forbidden => new ErrorViewModel
            {
                StatusCode = statusCode,
                Title = "Access denied",
                Message = "You do not have permission to perform this action."
            },

            _ => new ErrorViewModel
            {
                StatusCode = statusCode,
                Title = "Request error",
                Message = "The request could not be completed."
            }
        };

        Response.StatusCode = statusCode;

        return View("Error", model);
    }

    private static ErrorViewModel CreateErrorModel(Exception? exception)
    {
        return exception switch
        {
            ValidationException validationException => new ErrorViewModel
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Title = "Validation error",
                Message = validationException.Message
            },

            NotFoundException notFoundException => new ErrorViewModel
            {
                StatusCode = StatusCodes.Status404NotFound,
                Title = "Not found",
                Message = notFoundException.Message
            },

            ConflictException conflictException => new ErrorViewModel
            {
                StatusCode = StatusCodes.Status409Conflict,
                Title = "Conflict",
                Message = conflictException.Message
            },

            InvalidOperationException invalidOperationException =>
                new ErrorViewModel
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Title = "Operation not allowed",
                    Message = invalidOperationException.Message
                },

            _ => new ErrorViewModel
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Title = "Something went wrong",
                Message = "An unexpected error occurred. Please try again."
            }
        };
    }
}