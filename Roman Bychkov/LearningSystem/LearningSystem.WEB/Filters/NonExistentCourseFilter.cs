using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.WEB.Filters
{
    public class NonExistentCourseFilter : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var service = context.HttpContext.RequestServices.GetService(typeof(ICoursesService)) as ICoursesService;

            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Course does not exist" });
                return;
            }
            var id = context?.ActionArguments["id"]?.ToString();



            if (string.IsNullOrEmpty(id)
                || !int.TryParse(id, out int courseId)
                || (await service?.GetByIdAsync(courseId)) is null)
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Course does not exist" });
            else
                await next();
        }
    }
}
