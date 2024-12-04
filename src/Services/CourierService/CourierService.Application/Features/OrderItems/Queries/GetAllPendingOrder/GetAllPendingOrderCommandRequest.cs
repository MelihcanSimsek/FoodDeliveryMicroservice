using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Queries.GetAllPendingOrder
{
    public class GetAllPendingOrderCommandRequest : ISecuredRequest, IRequest<IList<GetAllPendingOrderCommandResponse>>
    {
        public string[] Roles => ["delivery.owner.courier"];
    }
}
