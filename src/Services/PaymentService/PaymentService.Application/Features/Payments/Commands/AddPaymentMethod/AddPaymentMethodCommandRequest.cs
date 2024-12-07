using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using PaymentService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CCV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public PaymentType Type { get; set; }
        public string[] Roles => ["user"];
    }
}
