using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Commands.BranchCreate
{
    public class BranchCreateCommandValidator : AbstractValidator<BranchCreateCommandRequest>
    {
        public BranchCreateCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30);
            RuleFor(p => p.City).NotEmpty().MinimumLength(3);
            RuleFor(p => p.District).NotEmpty().MinimumLength(3);
            RuleFor(p => p.Address).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(p => p.Phone).NotEmpty().MinimumLength(13).MaximumLength(13);
        }
    }
}
