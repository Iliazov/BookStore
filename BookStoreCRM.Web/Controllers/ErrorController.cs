using BookStoreCRM.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRM.Web.Controllers;

public class ErrorController : Controller
{
    [Route("Error")]
    public IActionResult Index()
    {
        var exception = HttpContext.Items["Exception"] as Exception;

        if (exception == null)
        {
            return View();
        }

        ViewBag.StatusCode = HttpContext.Response.StatusCode;
        ViewBag.Message = exception.Message;

        ViewBag.Title = exception switch
        {
            ValidationException => "Bad Request",
            NotFoundException => "Not Found",
            ConflictException => "Conflict",
            _ => "Internal Server Error"
        };

        return View();
    }
}