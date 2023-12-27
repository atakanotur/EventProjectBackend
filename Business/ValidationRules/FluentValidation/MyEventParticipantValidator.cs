using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MyEventParticipantValidator: AbstractValidator<Participant>
    {
        public MyEventParticipantValidator()
        {
            RuleFor(p => p.MyEventId).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(p => p.UserId).NotEmpty().WithMessage("Bu alan boş olamaz!");
        }
    }
}
