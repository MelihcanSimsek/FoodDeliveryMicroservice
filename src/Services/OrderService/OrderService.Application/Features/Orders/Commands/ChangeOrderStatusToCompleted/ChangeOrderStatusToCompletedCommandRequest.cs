using MediatR;
using OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToCompleted
{
    public class ChangeOrderStatusToCompletedCommandRequest : IRequest<bool>
    {
        public Guid OrderNumber { get; set; }
    }
}
