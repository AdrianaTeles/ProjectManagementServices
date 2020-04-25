namespace WebApplication1.Filters.ExceptionFilters
{
    using Application.DTO.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;


    /// <summary>
    /// Global exception filter class
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GlobalExceptionFilter()
        {
        }

        /// <summary>
        /// Action to take when an unhandled exception occurs
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            var response = new ErrorResponse()
            {
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
                DeclaredType = typeof(ErrorResponse)
            };
        }
    }
}