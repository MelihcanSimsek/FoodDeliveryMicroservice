using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantOrderService.Application.Bases;
using RestaurantOrderService.Application.Features.OrderItems.IntegrationEvents.Events;
using RestaurantOrderService.Application.Features.OrderItems.Rules;
using RestaurantOrderService.Application.Interfaces.CustomMapper;
using RestaurantOrderService.Application.Interfaces.UnitOfWorks;
using RestaurantOrderService.Domain.Entities;
using RestaurantOrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToAccepted
{
    public class ChangeOrderStatusToAcceptedCommandHandler : BaseHandler, IRequestHandler<ChangeOrderStatusToAcceptedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        private readonly IEventBus eventBus;
        public ChangeOrderStatusToAcceptedCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, OrderItemRules orderItemRules, IEventBus eventBus) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.orderItemRules = orderItemRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeOrderStatusToAcceptedCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.Status = OrderStatus.ACCEPTED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            var notificationEvent = new NotificationEmailIntegrationEvent(orderItem.UserEmail,
             $"Dear Customer,\n\n" +
             $"Your {orderItem.OrderNumber} has been accepted by Restaurant.\n" +
             $"Your order {orderItem.MenuName} is preparing for delivery!!\n\n" +
             "Thank you for choosing us.\n" +
             "Have a nice day.\n\n" +
             "---- This is a notification email ----");
            eventBus.Publish(notificationEvent);

            return Unit.Value;
        }
    }
}
