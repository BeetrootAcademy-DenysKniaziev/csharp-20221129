using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.WEB.Filters
{
    public class NotExistentArticleFilter : Attribute, IAsyncActionFilter
    {


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var service = context.HttpContext.RequestServices.GetService(typeof(IArticlesService)) as IArticlesService;

            if (!context.ActionArguments.ContainsKey("id") || !context.ActionArguments.ContainsKey("number"))
            {
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Lesson does not exist" });
                return;
            }
            var id = context?.ActionArguments["id"]?.ToString();
            var number = context?.ActionArguments["number"]?.ToString();


            if (string.IsNullOrEmpty(id)
                || !int.TryParse(id, out int courseId)
                || string.IsNullOrEmpty(number)
                || !int.TryParse(number, out int articleNumber)
                || (await service?.GetByNumberAsync(articleNumber, courseId)) is null)

                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Lesson does not exist" });
            else
                await next();
        }

    }
}
