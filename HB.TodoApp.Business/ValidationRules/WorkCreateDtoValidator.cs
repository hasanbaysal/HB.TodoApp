using FluentValidation;
using HB.TodoApp.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Business.ValidationRules
{
    public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            
            RuleFor(x => x.Defination).NotEmpty().WithMessage("definition is required");

            

        }
    }
}
