using CourierService.Application.Interfaces.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToOrderCompleted
{
    public class ChangeStatusToOrderCompletedCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public Guid OrderNumber { get; set; }
        public string[] Roles => ["courier"];
    }
}
