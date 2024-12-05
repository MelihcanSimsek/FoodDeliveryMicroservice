using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.UserEmail).NotEmpty();
            RuleFor(p => p.RestaurantAddress).NotEmpty();
            RuleFor(p => p.MenuName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.Quantity).GreaterThanOrEqualTo(1);
        }
    }
}
