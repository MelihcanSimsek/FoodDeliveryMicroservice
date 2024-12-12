using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToFailed
{
    public class ChangeOrderStatusToFailedCommandRequest : IRequest<bool>
    {
        public Guid OrderNumber { get; set; }
        public string FailMessage { get; set; }
    }
}
