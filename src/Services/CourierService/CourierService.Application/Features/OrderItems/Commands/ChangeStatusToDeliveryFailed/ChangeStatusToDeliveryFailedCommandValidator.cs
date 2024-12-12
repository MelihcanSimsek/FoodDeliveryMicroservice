using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryFailed
{
    public class ChangeStatusToDeliveryFailedCommandValidator : AbstractValidator<ChangeStatusToDeliveryFailedCommandRequest>
    {
        public ChangeStatusToDeliveryFailedCommandValidator()
        {
            RuleFor(p => p.Message).NotEmpty();
        }
    }
}
