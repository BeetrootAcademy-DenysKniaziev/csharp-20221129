//using Fluent.Infrastructure.FluentModel;
using ExchangeMarket.DAL;
using ExchangeMarket.Models;
//using Microsoft.EntityFrameworkCore;

namespace ExchangeMarket.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, MarketContext dbContext)
        {
            context.Items["MyData"] = "MyData";
            //Console.WriteLine($"LOG FROM MIDDLEWARE BEFORE!, {dbContext.Persons.Count()}");

            try
            {
                await _next(context);
            }
            catch (Exception)
            {
              

                throw;
            }

            
            //Console.WriteLine("LOG FROM MIDDLEWARE AFTER!");
        }
    }
}
