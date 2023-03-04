namespace Lesson35.HomeWork.Middleware
{
    internal class CheckTokenMiddleware
    {
        private readonly RequestDelegate _next;
        List<string> _whiteList;
        public CheckTokenMiddleware(RequestDelegate next, List<string> whiteList)
        {
            _next = next;
            _whiteList = whiteList;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["token"].ToString();

            if (_whiteList.Contains(token))
                await _next.Invoke(context);
            else
                context.Response.WriteAsync("You have not access!");
        }
    }
}



