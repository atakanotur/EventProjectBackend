using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MyEventValidator: AbstractValidator<MyEvent>
    {
        public MyEventValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.MyEventTypeId).NotEmpty();
            RuleFor(e => e.CreaterId).NotEmpty();
        }

    }
}
