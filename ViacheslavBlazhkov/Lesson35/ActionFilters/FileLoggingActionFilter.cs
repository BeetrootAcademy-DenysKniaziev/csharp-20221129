using Azure.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace Lesson35.ActionFilters
{
    public class FileLoggingActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            using (StreamWriter writer = new StreamWriter("filelog.txt", true))
            {
                writer.WriteLineAsync($"Request: {request.Method} {request.Path} {request.QueryString} | {DateTime.Now}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            using (StreamWriter writer = new StreamWriter("filelog.txt", true))
            {
                writer.WriteLineAsync($"Response: {response.StatusCode}\n");
            }
        }
    }
}
