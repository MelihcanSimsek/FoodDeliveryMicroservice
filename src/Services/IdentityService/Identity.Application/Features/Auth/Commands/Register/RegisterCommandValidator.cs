using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().MaximumLength(50);

            RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30);

            RuleFor(p => p.Password).NotEmpty();

            RuleFor(p => p.ConfirmPassword).NotEmpty().Equal(c => c.Password);
        }
    }
}
