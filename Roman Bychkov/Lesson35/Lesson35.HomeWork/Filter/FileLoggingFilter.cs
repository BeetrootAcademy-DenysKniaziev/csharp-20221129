using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class FileLoggingFilter : IActionFilter
{
    private readonly string _logFilePath;

    public FileLoggingFilter(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        var requestData = new StringBuilder();
        requestData.AppendLine($"Request URL: {request.Scheme}://{request.Host}{request.Path}");
        requestData.AppendLine($"Method: {request.Method}");
        requestData.AppendLine($"Headers: {request.Headers}");
        requestData.AppendLine($"Body: {GetRequestBody(request)}");
        File.AppendAllText(_logFilePath, requestData.ToString());
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
        {
            var response = context.HttpContext.Response;

            var responseData = new StringBuilder();
            responseData.AppendLine($"Status Code: {response.StatusCode}");
            responseData.AppendLine($"Headers: {response.Headers}");
            responseData.AppendLine($"Body: {GetResponseBody(response)}");

            File.AppendAllText(_logFilePath, responseData.ToString());
        }
    }

    private async Task<string> GetRequestBody(HttpRequest request)
    {
        request.EnableBuffering();
        var bodyReader = new StreamReader(request.Body);
        var requestBody = await bodyReader.ReadToEndAsync();
        request.Body.Position = 0;
        return requestBody;
    }

    private async Task<string> GetResponseBody(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var bodyReader = new StreamReader(response.Body);
        var responseBody = await bodyReader.ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return responseBody;
    }


}
