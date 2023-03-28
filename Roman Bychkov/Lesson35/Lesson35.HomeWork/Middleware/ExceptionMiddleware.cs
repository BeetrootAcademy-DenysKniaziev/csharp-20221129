using System.Text;
using System.Text.RegularExpressions;

namespace Lesson35.HomeWork.Middleware
{
    internal class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                context.Response.StatusCode = 400;
                var buffer = Encoding.UTF8.GetBytes("Bad Request 404!!!");
                context.Response.Body.WriteAsync(buffer, 0, buffer.Length);

            }
        }
    }
}



