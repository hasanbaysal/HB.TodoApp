using FluentValidation.Results;
using HB.TodoApp.Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Business.Extention
{
    public static class ValidationResultExtentions
    {
        
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            var list = new List<CustomValidationError>();
            validationResult.Errors.ForEach(x => list.Add(new() { ErrorMessage = x.ErrorMessage, ProppertyName = x.PropertyName }));
            return list;

        }
    }
}
