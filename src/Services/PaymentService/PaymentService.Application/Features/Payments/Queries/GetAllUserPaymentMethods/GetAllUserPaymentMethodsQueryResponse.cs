using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Queries.GetAllUserPaymentMethods
{
    public class GetAllUserPaymentMethodsQueryResponse
    {
        public Guid Id { get; set; }
        public string LastFourDigits { get; set; }
    }
}
