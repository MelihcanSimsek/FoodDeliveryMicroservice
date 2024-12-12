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

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToRejected
{
    public class ChangeOrderStatusToRejectedCommandHandler : BaseHandler, IRequestHandler<ChangeOrderStatusToRejectedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        private readonly IEventBus eventBus;
        public ChangeOrderStatusToRejectedCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, OrderItemRules orderItemRules, IEventBus eventBus) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.orderItemRules = orderItemRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeOrderStatusToRejectedCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.Status = OrderStatus.REJECTED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            var restaurantRejectedEvent = new RestaurantRejectedIntegrationEvent(orderItem.UserId,
                orderItem.OrderNumber, orderItem.UnitPrice, orderItem.Quantity, orderItem.UserEmail,
                request.Message);

            var notificationEvent = new NotificationEmailIntegrationEvent(orderItem.UserEmail,
             "Dear Customer,\n\n" +
             $"Your {orderItem.OrderNumber} has been cancelled by Restaurant.\n" +
             $"We will refund your money  [{orderItem.Quantity*orderItem.UnitPrice}] to your account !!\n\n" +
             "Thank you for choosing us.\n" +
             "Have a nice day.\n\n" +
             "---- This is a notification email ----");

            eventBus.Publish(restaurantRejectedEvent);
            eventBus.Publish(notificationEvent);

            return Unit.Value;
        }
    }
}
