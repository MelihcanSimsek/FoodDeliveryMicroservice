using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Queries.GetAllCourierActiveOrders
{
    public class GetAllCourierActiveOrdersQueryRequest : ISecuredRequest, IRequest<IList<GetAllCourierActiveOrdersQueryResponse>>
    {
        public string[] Roles => ["courier"];
    }
}
