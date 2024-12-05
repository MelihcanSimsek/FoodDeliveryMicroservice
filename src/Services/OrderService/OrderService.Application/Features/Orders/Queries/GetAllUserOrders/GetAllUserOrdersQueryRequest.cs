using MediatR;
using OrderService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Queries.GetAllUserOrders
{
    public class GetAllUserOrdersQueryRequest : IRequest<IList<GetAllUserOrdersQueryResponse>>, ISecuredRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string[] Roles => ["user"];
    }
}
