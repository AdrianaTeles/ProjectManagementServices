using Application.DTO.Responses;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace WebApplication1.Filters.ActionFilters
{
    /// <summary>
    /// Api validation filter
    /// </summary>
    public class ApiValidationResultFilter : ResultFilterAttribute
    {
        /// <summary>
        /// Transform errors into ApiResponse
        /// </summary>
        /// <param name="context">Current action context</param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            switch (context.Result)
            {
                case BadRequestObjectResult badResult:
                    {
                        var errors = context.ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                        context.Result = new BadRequestObjectResult(new ApiResponse(400, true, errors));
                        break;
                    }
            }
        }
    }
}
