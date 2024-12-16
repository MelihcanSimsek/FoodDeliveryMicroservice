using MediatR;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using PaymentService.Application.Interfaces.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.UpdateBalanceForOrder
{
    public class DownBalanceForOrderCommandRequest : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public List<EventPaymentItem> EventPaymentItems { get; set; }
    }
}
