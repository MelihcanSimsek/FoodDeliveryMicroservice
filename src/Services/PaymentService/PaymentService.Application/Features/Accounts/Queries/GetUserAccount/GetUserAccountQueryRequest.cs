using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Queries.GetUserAccount
{
    public class GetUserAccountQueryRequest : IRequest<GetUserAccountQueryResponse>, ISecuredRequest
    {
        public string[] Roles => ["user"];
    }
}
