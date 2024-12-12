using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.StartOrder
{
    public class StartOrderCommandValidator : AbstractValidator<StartOrderCommandRequest>
    {
        public StartOrderCommandValidator()
        {
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.RestaurantAddress).NotEmpty();
            RuleFor(p => p.UserEmail).NotEmpty();
        }
    }
}
