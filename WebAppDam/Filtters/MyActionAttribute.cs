using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppDam.Filtters
{
    public class MyActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
