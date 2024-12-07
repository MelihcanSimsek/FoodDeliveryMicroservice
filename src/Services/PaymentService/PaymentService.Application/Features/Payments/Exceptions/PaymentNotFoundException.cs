using PaymentService.Application.Exceptions;
using PaymentService.Application.Features.Payments.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Exceptions
{
    public class PaymentNotFoundException : BusinessException
    {
        public PaymentNotFoundException() : base(Messages.PaymentMethodDoesNotExists)
        {
            
        }
    }
}
