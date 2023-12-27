using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator: AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email alanı boş olamaz!");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Bu alan boş olamaz!");
            RuleFor(u => u.Password).Length(6, 20).WithMessage("Bu alanın uzunluğu 6 ile 20 karakter arasında olmalıdır!");
        }
    }
}
