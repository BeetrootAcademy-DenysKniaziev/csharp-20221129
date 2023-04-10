using Newtonsoft.Json;

namespace Lesson35.HomeWork.Filter
{
    public class ConsoleLogFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            Console.WriteLine($"[REQUEST] {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
            Console.WriteLine($"[HEADERS] {JsonConvert.SerializeObject(context.HttpContext.Request.Headers, Formatting.Indented)}");

            if (context.ActionArguments.Count > 0)
                    Console.WriteLine($"[BODY] {JsonConvert.SerializeObject(context.ActionArguments, Formatting.Indented)}");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

            var response = context.HttpContext.Response;

            Console.WriteLine($"[RESPONSE] {response.StatusCode}");
            Console.WriteLine($"[HEADERS] {JsonConvert.SerializeObject(response.Headers, Formatting.Indented)}");
            try
            {
                if (context.Result is ObjectResult objectResult)
                    Console.WriteLine($"[BODY] {JsonConvert.SerializeObject(objectResult.Value, Formatting.Indented)}");
                else if (context.Result is ContentResult contentResult)
                    Console.WriteLine($"[BODY] {contentResult.Content}");
            }
            catch (Exception ex)
            { }
                
        }
    }
}
