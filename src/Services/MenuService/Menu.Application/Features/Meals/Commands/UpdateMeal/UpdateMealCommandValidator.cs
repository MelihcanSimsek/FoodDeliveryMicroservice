using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandValidator:AbstractValidator<UpdateMealCommandRequest>
    {
        public UpdateMealCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Gram).GreaterThanOrEqualTo(50);
        }
    }
}
