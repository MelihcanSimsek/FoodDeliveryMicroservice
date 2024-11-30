using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.Revoke
{
    internal class RevokeCommandValidator :AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30);
        }
    }
}
