using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Queries.GetAllCourier
{
    public class GetAllCourierQueryRequest : IRequest<IList<GetAllCourierQueryResponse>>,ISecuredRequest
    {
        public string[] Roles => ["delivery.owner.restaurant", "courier", "admin"];
    }
}
