using System.Text;

namespace Lesson35.Middlewares
{
    public class SwaggerNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && context.Request.Path.StartsWithSegments("/swagger"))
            {
                context.Response.StatusCode = 999;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<center><h1>What are you doing, MAN !?</h1></center>");
            }
        }
    }
}
