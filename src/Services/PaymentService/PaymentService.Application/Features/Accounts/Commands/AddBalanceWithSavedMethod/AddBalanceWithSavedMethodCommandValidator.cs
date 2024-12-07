using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.AddBalanceWithSavedMethod
{
    public class AddBalanceWithSavedMethodCommandValidator : AbstractValidator<AddBalanceWithSavedMethodCommandRequest>
    {
        public AddBalanceWithSavedMethodCommandValidator()
        {
            RuleFor(p => p.Amount).GreaterThan(0);
        }
    }
}
