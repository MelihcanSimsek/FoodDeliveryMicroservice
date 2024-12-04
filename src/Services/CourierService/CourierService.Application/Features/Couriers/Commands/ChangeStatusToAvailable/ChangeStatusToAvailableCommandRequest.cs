using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Commands.ChangeStatusToAvailable
{
    public class ChangeStatusToAvailableCommandRequest : IRequest<Unit>,ISecuredRequest
    {
        public string[] Roles => ["delivery.owner.courier"];
    }
}
