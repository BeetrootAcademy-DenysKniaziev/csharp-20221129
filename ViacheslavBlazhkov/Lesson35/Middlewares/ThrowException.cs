using System.Text;

namespace Lesson35.Middlewares
{
    public class ThrowException
    {
        private readonly RequestDelegate _next;

        public ThrowException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = 999;

            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("<center><h1>What are you doing, MAN !?</h1></center>");

            await _next(context);
        }
    }
}
