namespace LearningSystem.WEB.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Recieved {context.Request.Method} {context.Request.Path}");

            try
            {
                await _next?.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured: {ex.Message}");
                throw;
            }
            finally
            {
                _logger.LogInformation($"Returned {context.Response.StatusCode}");
            }
        }
    }
}
