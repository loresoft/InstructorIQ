using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstructorIQ.Core.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
        }

        public ErrorModel(ModelStateDictionary modelState)
        {
            if (modelState == null)
                throw new ArgumentNullException(nameof(modelState));

            if (modelState.IsValid)
                return;

            Code = "422";
            Message = "Invalid model state";
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationErrorModel(key, x.ErrorMessage)))
                .ToList();
        }


        public string Code { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public IList<ValidationErrorModel> Errors { get; set; }
    }
}
