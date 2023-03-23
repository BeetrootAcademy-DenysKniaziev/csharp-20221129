using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net;
using System.Text.Json;
using System.Net.Http;


namespace ExchangeMarket.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //try
            //{
            //    Console.WriteLine("Exception!!!");
            //    await _next(context);
            //}
            //catch (Exception ex)
            //{
            //    await HandleExceptionAsync(context, ex);
            //}
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var originalBodyStream = context.Response.Body;

            try
            {
                using (var responseBodyStream = new MemoryStream())
                {
                    context.Response.Body = responseBodyStream;

                    await _next(context);

                    responseBodyStream.Seek(0, SeekOrigin.Begin);

                    var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();

                    // Log the response body here


                    responseBodyStream.Seek(0, SeekOrigin.Begin);

                    try
                    {
                        var jsonObject = JObject.Parse(responseBody);

                        var statusCode = (int)jsonObject["status"];
                        //var body = jsonObject["body"].ToString();
                        //Console.WriteLine(body);
                        if (statusCode > 200)
                        {
                            Console.WriteLine(responseBody);
                            Console.WriteLine($"\n\n\n I found this F*** Swagger Respose Error and now can do anything with it\nThis time the Exception is \n Original Status code: {statusCode}");
                            throw new Exception(statusCode.ToString());
                        }
                    } 
                    catch (Exception ex) 
                    {
                        string statusCode = context.Response.StatusCode.ToString();
                        //string body = await new StreamReader(context.Response.Body).ReadToEndAsync(); //hanging web

                        string message = "Keep Calm";
                        if (ex.Message != "200")
                        {
                            //statusCode = HttpStatusCode.BadRequest;
                            statusCode = statusCode + "1";
                            message = "Do not be affraid, about " + ex.Message;

                            Console.WriteLine("My Status code " + statusCode + "\n" + message);// + "\n" + body );
                        }

                       //Console.WriteLine($"Response body: {JsonSerializer.Serialize(responseBody)}");

                        

                    }


                    await responseBodyStream.CopyToAsync(originalBodyStream);
                }
            }

            finally
            {
                context.Response.Body = originalBodyStream;
                //await _next(context);
            }


        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message = exception.Message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(InvalidOperationException))
            {
                status = HttpStatusCode.NotFound;
            }
            //else if (exceptionType == typeof(PasswordIncorrectException))
            //{
            //    status = HttpStatusCode.Unauthorized;
            //}
            if (exception is ArgumentException && context.Response.StatusCode == 400)
            {
                status = HttpStatusCode.BadRequest;
                message = "Do not be affraid, with " + exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
            }


            var exceptionResult = message;//JsonSerializer.Serialize(new { error = message, exception.StackTrace });
           // context.Response.ContentType = "application/json";
           // context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}