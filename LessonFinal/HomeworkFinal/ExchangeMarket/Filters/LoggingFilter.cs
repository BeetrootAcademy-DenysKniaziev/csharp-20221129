using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using System;

namespace ExchangeMarket.Filters
{
    public class LoggingFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //var request = context.HttpContext.Request;
            //var response = context.HttpContext.Response;
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($"Request - Method: {request.Method}, Path: {request.Path}");
            //Console.WriteLine($"Response - Status code: {response.StatusCode}, Content type: {response.ContentType}");
            var request = context.HttpContext.Request;
            var requestData = new
            {
                Method = request.Method,
                Path = request.Path
            };
            var json = JsonConvert.SerializeObject(requestData);
            Log.Information(json);

        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //var request = context.HttpContext.Request;
            //var response = context.HttpContext.Response;
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine($"Request - Method: {request.Method}, Path: {request.Path}");
            //Console.WriteLine($"Response - Status code: {response.StatusCode}, Content type: {response.ContentType}");
            var response = context.HttpContext.Response;
            var responseData = new
            {
                StatusCode = response.StatusCode,
                ContentType = response.ContentType
            };
            var json = JsonConvert.SerializeObject(responseData);
            Log.Information(json);
        }
    }

    public class SecondLoggingFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Request - Method: {request.Method}, Path: {request.Path}");
            Console.WriteLine($"Response - Status code: {response.StatusCode}, Content type: {response.ContentType}");

        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Request - Method: {request.Method}, Path: {request.Path}");
            Console.WriteLine($"Response - Status code: {response.StatusCode}, Content type: {response.ContentType}");
        }
    }
}

