﻿using CourierService.Application.Bases;
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

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryStarted
{
    public class ChangeStatusToDeliveryStartedCommandHandler : BaseHandler, IRequestHandler<ChangeStatusToDeliveryStartedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        private readonly IEventBus eventBus;
        public ChangeStatusToDeliveryStartedCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, OrderItemRules orderItemRules, IEventBus eventBus) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.orderItemRules = orderItemRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeStatusToDeliveryStartedCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.CourierUserId == null);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            orderItem.CourierUserId = courierUserId;
            orderItem.OrderStatus = OrderStatus.DELIVERY_STARTED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            var notificationEvent = new NotificationEmailIntegrationEvent(orderItem.UserEmail,
             "Dear Customer,\n\n" +
             $"Your {orderItem.OrderNumber} has been started delivery by Courier.\n" +
             "We will deliver your order to your Address in 30 minutes !!\n\n" +
             "Thank you for choosing us.\n" +
             "Have a nice day.\n\n" +
             "---- This is a notification email ----");
            eventBus.Publish(notificationEvent);

            return Unit.Value;
        }
    }
}
