using Microsoft.AspNetCore.Mvc.Filters;

namespace Lesson35.Classwork.Filters
{
    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("LOG FROM FILTER BEFORE!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.StatusCode = 201;
            Console.WriteLine("LOG FROM FILTER AFTER!");
        }
    }

    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("LOG FROM FILTER BEFORE!");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.StatusCode = 201;
            Console.WriteLine("LOG FROM FILTER AFTER!");
        }
    }
}
