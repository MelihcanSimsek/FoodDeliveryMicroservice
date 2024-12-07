using MediatR;
using PaymentService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Queries.GetAllUserPaymentMethods
{
    public class GetAllUserPaymentMethodsQueryRequest : ISecuredRequest, IRequest<IList<GetAllUserPaymentMethodsQueryResponse>>
    {
        public string[] Roles => ["user"];
    }
}
