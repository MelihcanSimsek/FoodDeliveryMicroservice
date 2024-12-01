using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Commands.UpdateLiquid
{
    public class UpdateLiquidCommandValidator : AbstractValidator<UpdateLiquidCommandRequest>
    {
        public UpdateLiquidCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Milliliter).GreaterThanOrEqualTo(100);
        }
    }
}
