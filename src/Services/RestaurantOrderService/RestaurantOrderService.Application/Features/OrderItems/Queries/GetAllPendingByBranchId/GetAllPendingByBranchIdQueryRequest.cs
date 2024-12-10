using MediatR;
using RestaurantOrderService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllPendingByBranchId
{
    public class GetAllPendingByBranchIdQueryRequest : ISecuredRequest, IRequest<IList<GetAllPendingByBranchIdQueryResponse>>
    {
        public Guid BranchId { get; set; }
        public string[] Roles => ["delivery.owner.restaurant"];
    }
}
