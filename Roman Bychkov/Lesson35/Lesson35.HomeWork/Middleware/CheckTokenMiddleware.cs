namespace Lesson35.HomeWork.Middleware
{
    internal class CheckTokenMiddleware
    {
        private readonly RequestDelegate _next;
        List<Guid> _whiteList;
        public CheckTokenMiddleware(RequestDelegate next, List<Guid> whiteList)
        {
            _next = next;
            _whiteList = whiteList;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var valid = Guid.TryParse(context.Request.Headers["token"].ToString(), out Guid result);

            if (valid && _whiteList.Contains(result))
                await _next.Invoke(context);
            else if(!valid)
            {
                context.Response.StatusCode = 401;
                context.Response.WriteAsync("Invalid token");
            }
            else
            {
                context.Response.StatusCode = 403;
                context.Response.WriteAsync("You have not access!");
            }
        }
    }
}



