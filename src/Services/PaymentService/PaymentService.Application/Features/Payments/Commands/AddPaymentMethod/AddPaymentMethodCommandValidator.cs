using FluentValidation;
using PaymentService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandValidator : AbstractValidator<AddPaymentMethodCommandRequest>
    {
        public AddPaymentMethodCommandValidator()
        {
            RuleFor(p => p.CardName).NotEmpty().MaximumLength(28);
            RuleFor(p => p.CardNumber).NotEmpty().CreditCard().MinimumLength(16).MaximumLength(16);
            RuleFor(p => p.CCV).NotEmpty().CreditCard().MinimumLength(3).MaximumLength(3);
            RuleFor(p => p.ExpiryDate).GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
