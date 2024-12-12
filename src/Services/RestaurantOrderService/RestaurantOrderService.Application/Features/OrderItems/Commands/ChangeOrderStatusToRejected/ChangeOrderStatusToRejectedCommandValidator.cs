using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToRejected
{
    public class ChangeOrderStatusToRejectedCommandValidator : AbstractValidator<ChangeOrderStatusToRejectedCommandRequest>
    {
        public ChangeOrderStatusToRejectedCommandValidator()
        {
            RuleFor(p => p.Message).NotEmpty();
        }
    }
}
