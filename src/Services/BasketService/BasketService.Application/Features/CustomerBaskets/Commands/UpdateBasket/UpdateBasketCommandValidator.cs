using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.UpdateBasket
{
    public class UpdateBasketCommandValidator : AbstractValidator<UpdateBasketCommandRequest>
    {
        public UpdateBasketCommandValidator()
        {
            RuleFor(p => p.UnitPrice).GreaterThan(0); 
            RuleFor(p => p.Quantity).GreaterThanOrEqualTo(1); 
            RuleFor(p => p.MenuName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(p => p.Type).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.RestaurantId).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
        }
    }
}
