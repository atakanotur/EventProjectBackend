using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MyEventTypeValidator: AbstractValidator<MyEventType>
    {
        public MyEventTypeValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Bu alan boş olamaz!");
        }
    }
}
