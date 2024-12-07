using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string[] Roles => ["user"];
    }
}
