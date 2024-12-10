using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommandRequest>
    {
        public CreateOrderItemCommandValidator()
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
