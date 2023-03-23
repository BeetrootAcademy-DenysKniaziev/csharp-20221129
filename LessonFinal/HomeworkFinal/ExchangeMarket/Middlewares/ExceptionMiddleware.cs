using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception here if needed
            Console.WriteLine($"Exception occurred: {ex.Message}");

            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // Create a JSON response body with the error message
            var responseBody = new
            {
                message = ex.Message
            };

            // Convert the response body to a byte array and write it to the response stream
            var responseBodyBytes = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(responseBody));
            await context.Response.Body.WriteAsync(responseBodyBytes);


            // Write the response body to the console
            Console.WriteLine($"Response body: {JsonSerializer.Serialize(responseBody)}");


            return;
        }
    }
}