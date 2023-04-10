using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.WEB.Filters
{
    public class NonAccessToChangeCourse : Attribute, IAsyncActionFilter
    {
     

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var user = context.HttpContext.User;

            var service = context.HttpContext.RequestServices.GetService(typeof(ICoursesService)) as ICoursesService;
            string id;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = context?.ActionArguments["id"]?.ToString();
            }
            else if (context.ActionArguments.ContainsKey("model"))
            {
                var model = context?.ActionArguments["model"] as CourseModel;
                id = model?.Id.ToString();
            }
            else
            {
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "You have not acces to this course " });
                return;
            }

            if (string.IsNullOrEmpty(id)
                  || !int.TryParse(id, out int courseId)
                  || !((await service?.GetByIdUserIncludesAsync(courseId))?.User.UserName == user?.Identity?.Name)
                 )
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "You have not acces to this course " });
            else
                await next();
        }
    }
}
