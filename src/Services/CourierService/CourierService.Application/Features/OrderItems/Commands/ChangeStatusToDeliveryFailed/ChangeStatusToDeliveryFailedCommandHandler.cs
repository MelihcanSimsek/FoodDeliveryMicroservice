using CourierService.Application.Bases;
using CourierService.Application.Extensions;
using CourierService.Application.Features.OrderItems.IntegrationEvents.Events;
using CourierService.Application.Features.OrderItems.Rules;
using CourierService.Application.Interfaces.CustomMapper;
using CourierService.Application.Interfaces.UnitOfWorks;
using CourierService.Domain.Entites;
using CourierService.Domain.Enums;
using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryFailed
{
    public class ChangeStatusToDeliveryFailedCommandHandler : BaseHandler, IRequestHandler<ChangeStatusToDeliveryFailedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        private readonly IEventBus eventBus;
        public ChangeStatusToDeliveryFailedCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, OrderItemRules orderItemRules, IEventBus eventBus) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.orderItemRules = orderItemRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeStatusToDeliveryFailedCommandRequest request, CancellationToken cancellationToken)
        {
            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.CourierUserId == courierUserId);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.OrderStatus = OrderStatus.DELIVERY_FAILED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            var deliveryFailedEvent = new DeliveryFailedIntegrationEvent(orderItem.UserId,
                orderItem.OrderNumber, orderItem.UnitPrice, orderItem.Quantity, orderItem.UserEmail,
                request.Message);
            var notificationEvent = new NotificationEmailIntegrationEvent(orderItem.UserEmail,
             "Dear Customer,\n\n" +
             $"Your {orderItem.OrderNumber} has been failed by Courier.\n" +
             $"We will refund your money [{orderItem.Quantity*orderItem.UnitPrice}] to your account !!\n\n" +
             "Thank you for choosing us.\n" +
             "Have a nice day.\n\n" +
             "---- This is a notification email ----");

            eventBus.Publish(deliveryFailedEvent);
            eventBus.Publish(notificationEvent);

            return Unit.Value;
        }
    }
}
