using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using PaymentService.Application.Interfaces.Transactional;
using PaymentService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.AddBalanceWithMethod
{
    public class AddBalanceWithMethodCommandRequest : IRequest<Unit>, ISecuredRequest, ITransactionalEvent
    {
        public string CardNumber { get; set; }
        public string CCV { get; set; }
        public string CardName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public PaymentType Type { get; set; }
        public decimal Amount { get; set; }
        public string[] Roles => ["user"];
    }
}
