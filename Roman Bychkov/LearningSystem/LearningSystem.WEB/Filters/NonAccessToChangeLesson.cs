using LearningSystem.WEB.ValidationModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningSystem.WEB.Filters
{
    public class NonAccessToChangeLesson : Attribute, IAsyncActionFilter
    {
        private Type _serviceType;
        public NonAccessToChangeLesson(Type serviceType)
        {
            _serviceType = serviceType;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var user = context.HttpContext.User;
            var serviceProvider = context.HttpContext.RequestServices;
            var service = serviceProvider.GetService(_serviceType) as ICoursesService;
            string id, number;

            if (context.ActionArguments.ContainsKey("id") && context.ActionArguments.ContainsKey("number"))
            {
                id = context?.ActionArguments["id"]?.ToString();
                number = context?.ActionArguments["number"]?.ToString();
            }
            else if(context.ActionArguments.ContainsKey("model"))
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

                   

            if (string.IsNullOrEmpty(id)
                  || !int.TryParse(id, out int courseId)
                  || string.IsNullOrEmpty(number)
                  || !byte.TryParse(number, out byte articleNumber)
                  || !((await service?.GetByIdAsync(courseId))?.User.UserName==user?.Identity?.Name)
                  || !((await service?.GetByIdAsync(courseId)).Articles.Exists(a=>a.Number == articleNumber))
                    )
                context.Result = new RedirectToActionResult("Oops", "Home", new { message = "You have not acces to this lesson " });
            else
                await next();
        }
    }
}
