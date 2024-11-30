using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30); ;
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
