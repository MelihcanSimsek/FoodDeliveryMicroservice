using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.UpBalanceForOrder
{
    public class UpBalanceForOrderCommandRequest : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid OrderNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string UserEmail { get; set; }
        public string FailMessage { get; set; }
        public Type Type { get; set; }
    }
}
