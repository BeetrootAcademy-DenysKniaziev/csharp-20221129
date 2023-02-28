using Lesson35.Classwork.Model;

namespace Lesson35.Classwork.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            context.Items["MyData"] = "MyData";
            Console.WriteLine($"LOG FROM MIDDLEWARE BEFORE!, {dbContext.Persons.Count()}");

            try
            {
                await _next(context);
            }
            catch (Exception)
            {
              

                throw;
            }

            
            Console.WriteLine("LOG FROM MIDDLEWARE AFTER!");
        }
    }
}
