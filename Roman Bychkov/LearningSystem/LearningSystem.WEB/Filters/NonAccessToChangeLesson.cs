using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.WEB.Filters
{
    public class NonAccessToChangeLesson : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var user = context.HttpContext.User;
            var service = context.HttpContext.RequestServices.GetService(typeof(ICoursesService)) as ICoursesService;
            string id, number;

            if (context.ActionArguments.ContainsKey("id") && context.ActionArguments.ContainsKey("number"))
            {
                id = context?.ActionArguments["id"]?.ToString();
                number = context?.ActionArguments["number"]?.ToString();
            }
            else if (context.ActionArguments.ContainsKey("model"))
            {
                var model = context?.ActionArguments["model"] as LessonModel;
                number = model?.Number.ToString();
                id = model?.CourseId.ToString();
            }
            else
            {
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Lesson does not exist" });
                return;
            }



            if (!string.IsNullOrEmpty(id)
                  && int.TryParse(id, out int courseId)
                  && !string.IsNullOrEmpty(number)
                  && byte.TryParse(number, out byte articleNumber))
            {
                var course = await service?.GetByIdUserArticleIncludesAsync(courseId);
                if (course != null && course.Articles.Exists(a => a.Number == articleNumber) && course.User.UserName == user.Identity?.Name)
                    await next();
                else
                    context.Result = new RedirectToActionResult("Oops", "Home", new { message = "You have not acces to this lesson " });
            }
            else
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "Lesson does not exist" });
        }
    }
}
