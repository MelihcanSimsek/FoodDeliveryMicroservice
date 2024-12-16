using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(P => P.RoleName).NotEmpty();
        }
    }
}
