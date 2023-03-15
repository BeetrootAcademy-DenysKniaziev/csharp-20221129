using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;

namespace Lesson35.ActionFilters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var requestBody = request.Body;

            _logger.LogInformation($"Request: {request.Method} {request.Path} {request.QueryString}");
            
            //if (requestBody.CanSeek)
            //{
            //    requestBody.Seek(0, SeekOrigin.Begin);
            //    var requestBodyContent = new StreamReader(requestBody).ReadToEnd();
            //    requestBody.Seek(0, SeekOrigin.Begin);
            //    _logger.LogInformation($"Request Body: {requestBodyContent}");
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;
            var responseBody = response.Body;

            _logger.LogInformation($"Response: {response.StatusCode}");

            if (responseBody.CanSeek)
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyContent = new StreamReader(responseBody).ReadToEnd();
                responseBody.Seek(0, SeekOrigin.Begin);
                _logger.LogInformation($"Response Body: {responseBodyContent}");
            }
        }
    }
}
