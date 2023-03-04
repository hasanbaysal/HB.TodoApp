using FluentValidation;
using HB.TodoApp.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.Business.ValidationRules
{
    public class WorkUpdateDtoValidator :AbstractValidator<WorkUpdateDto>
    {

        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Defination).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();

        }

    }
}
