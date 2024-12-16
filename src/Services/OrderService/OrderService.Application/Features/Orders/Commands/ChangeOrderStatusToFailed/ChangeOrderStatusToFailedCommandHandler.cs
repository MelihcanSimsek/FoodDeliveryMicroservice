using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Bases;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;
using OrderService.Application.Features.Orders.Rules;
using OrderService.Application.Interfaces.CustomMapper;
using OrderService.Application.Interfaces.UnitOfWorks;
using OrderService.Domain.Entities;
using OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToFailed
{
    public class ChangeOrderStatusToFailedCommandHandler : BaseHandler, IRequestHandler<ChangeOrderStatusToFailedCommandRequest, bool>
    {
        private readonly OrderRules orderRules;
        private readonly IEventBus eventBus;
        public ChangeOrderStatusToFailedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, OrderRules orderRules, IEventBus eventBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.orderRules = orderRules;
            this.eventBus = eventBus;
        }

        public async Task<bool> Handle(ChangeOrderStatusToFailedCommandRequest request, CancellationToken cancellationToken)
        {
            Order? order = await unitOfWork.GetReadRepository<Order>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.Status == OrderStatus.ORDER_STARTED);
            await orderRules.ShouldOrderExists(order);

            order.Status = OrderStatus.ORDER_FAILED;
            order.FailMessage = request.FailMessage;

            await unitOfWork.GetWriteRepository<Order>().UpdateAsync(order);
            await unitOfWork.SaveAsync();

            var notificationEvent = new NotificationEmailIntegrationEvent(order.UserEmail,
              $"Dear Customer,\n\n" +
              $"Your {order.OrderNumber} has been failed.\n" +
              $"Your order {order.Type},{order.MenuName},{order.Quantity} is failed at {order.CreationDate.ToShortTimeString()} !!\n\n" +
              $"We already refund your money  [{order.Quantity * order.UnitPrice}] to your account !!\n\n"+
              "Thank you for choosing us.\n" +
              "Have a nice day.\n\n" +
              "---- This is a notification email ----");
            eventBus.Publish(notificationEvent);

            return true;
        }
    }
}
