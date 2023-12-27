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
            RuleFor(e => e.Name).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(e => e.Address).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(e => e.MyEventTypeId).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(e => e.UserId).NotEmpty().WithMessage("Bu alan boş olamaz!");
        }

    }
}
