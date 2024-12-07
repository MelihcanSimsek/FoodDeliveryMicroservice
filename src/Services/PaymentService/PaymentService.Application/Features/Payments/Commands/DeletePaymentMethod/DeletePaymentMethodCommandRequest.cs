using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string[] Roles => ["user"];
    }
}
