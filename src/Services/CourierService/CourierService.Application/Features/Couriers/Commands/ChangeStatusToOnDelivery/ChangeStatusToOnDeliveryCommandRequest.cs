using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Commands.ChangeStatusToOnDelivery
{
    public class ChangeStatusToOnDeliveryCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public string[] Roles => ["delivery.owner.courier"];
    }
}
