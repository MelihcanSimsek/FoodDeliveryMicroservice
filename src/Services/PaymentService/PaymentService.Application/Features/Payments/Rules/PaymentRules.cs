using PaymentService.Application.Bases;
using PaymentService.Application.Features.Payments.Exceptions;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Rules
{
    public class PaymentRules : BaseRules
    {
        public async Task ShouldPaymentMethodExists(PaymentCard? paymentCard)
        {
            if (paymentCard is null) throw new PaymentNotFoundException();
        }

        public async Task ShouldPaymentMethodCanNotBeDuplicate(PaymentCard? paymentCard)
        {
            if (paymentCard is not null) throw new PaymentMethodAlreadyExistsException();
        }
    }
}
