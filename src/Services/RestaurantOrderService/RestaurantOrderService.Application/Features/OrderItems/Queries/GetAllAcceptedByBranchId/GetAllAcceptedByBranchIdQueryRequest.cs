using MediatR;
using RestaurantOrderService.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllAcceptedByBranchId
{
    public class GetAllAcceptedByBranchIdQueryRequest : ISecuredRequest, IRequest<IList<GetAllAcceptedByBranchIdQueryResponse>>
    {
        public Guid BranchId { get; set; }
        public string[] Roles => ["restaurantworker"];
    }
}
