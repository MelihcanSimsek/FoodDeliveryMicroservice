using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.CheckBalanceForOrder
{
    public class CheckBalanceForOrderCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public decimal TotalAmount { get; set; }
        public string[] Roles => ["user"];
    }
}
