using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Codibly.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {

            if (context.Exception is ValidationException validationException)
            {
                context.Result = new BadRequestObjectResult(new { ValidationErrors = validationException.Errors });
            }
            else
            {
                var jsonErrorResponse = new
                {
                    Messages = new[] { "An internal error has occurred" },
                    Exception = context.Exception.ToString()
                };


                context.Result = new ObjectResult(jsonErrorResponse) 
                {    
                    StatusCode = StatusCodes.Status500InternalServerError 
                };
            }

            context.ExceptionHandled = true;

        }
    }
}
