using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator: AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Password).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(u => u.Password).Length(6,20).WithMessage("Bu alanın uzunluğu 6 ile 20 karakter arasında olmalıdır!");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email alanı boş olamaz!");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(u => u.FirstName).Length(3,15).WithMessage("Bu alanın uzunluğu 3 ile 15 karakter arasında olmalıdır!");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(u => u.LastName).Length(3,15).WithMessage("Bu alanın uzunluğu 3 ile  karakter arasında olmalıdır!");
        }
    }
}
