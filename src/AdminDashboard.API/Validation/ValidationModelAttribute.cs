using AdminDashboard.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminDashboard.API.Validation;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var result = ControllerUtils.DefineModelStateErrorDictionary(context.ModelState);
            context.Result = new BadRequestObjectResult(result);
        }
    }
}
