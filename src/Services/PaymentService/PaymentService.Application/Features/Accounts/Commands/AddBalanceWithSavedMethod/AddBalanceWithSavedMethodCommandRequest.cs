using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using PaymentService.Application.Interfaces.Transactional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.AddBalanceWithSavedMethod
{
    public class AddBalanceWithSavedMethodCommandRequest : IRequest<Unit>, ISecuredRequest,ITransactionalEvent
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string[] Roles => ["user"];
    }
}
