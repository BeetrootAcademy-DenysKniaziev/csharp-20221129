using Microsoft.AspNetCore.Mvc.Filters;

namespace Lesson35.ActionFilters
{
    public class ConsoleLoggingActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Request: {request.Method} {request.Path} {request.QueryString}");
            Console.ResetColor();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Response: {response.StatusCode}");
            Console.ResetColor();
        }
    }
}
