using System.Linq;
using InstructorIQ.Core.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstructorIQ.Web.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var errors = context.ModelState.Keys
                .SelectMany(key => context.ModelState[key].Errors.Select(x => new ValidationErrorModel(key, x.ErrorMessage)))
                .ToList();

            var result = new ErrorModel
            {
                Code = "422",
                Message = "Validation Failed",
                Errors = errors
            };

            // return error with status code 422 (Unprocessable Entity)
            context.Result = new ObjectResult(result) { StatusCode = 422 };
        }
    }
}
