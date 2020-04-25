namespace WebApplication1.Filters.ActionFilters
{
    using System.Linq;
    using Application.DTO.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Api validation filter
    /// </summary>
    public class ApiValidationFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Actions to apply before the request reaches the controller
        /// </summary>
        /// <param name="context">Current action context</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new ApiResponse(400, true, errors));
            }

            base.OnActionExecuting(context);
        }
    }
}
