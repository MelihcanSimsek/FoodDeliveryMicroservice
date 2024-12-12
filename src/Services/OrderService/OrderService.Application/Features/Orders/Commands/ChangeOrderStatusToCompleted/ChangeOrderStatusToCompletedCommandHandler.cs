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

namespace OrderService.Application.Features.Orders.Commands.ChangeOrderStatusToCompleted
{
    public class ChangeOrderStatusToCompletedCommandHandler : BaseHandler, IRequestHandler<ChangeOrderStatusToCompletedCommandRequest, bool>
    {
        private readonly OrderRules orderRules;
        private readonly IEventBus eventBus;
        public ChangeOrderStatusToCompletedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, OrderRules orderRules, IEventBus eventBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.orderRules = orderRules;
            this.eventBus = eventBus;
        }

        public async Task<bool> Handle(ChangeOrderStatusToCompletedCommandRequest request, CancellationToken cancellationToken)
        {
            Order? order = await unitOfWork.GetReadRepository<Order>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.Status == OrderStatus.ORDER_STARTED);
            await orderRules.ShouldOrderExists(order);

            Order newOrder = new Order()
            {
                RestaurantId = order.RestaurantId,
                BranchId = order.BranchId,
                UserId = order.UserId,
                MenuName = order.MenuName,
                Quantity = order.Quantity,
                OrderNumber = order.OrderNumber,
                Status = OrderStatus.ORDER_COMPLETED,
                RestaurantAddress = order.RestaurantAddress,
                UnitPrice = order.UnitPrice,
                UserEmail = order.UserEmail,
                Address = order.Address,
            };

            await unitOfWork.GetWriteRepository<Order>().AddAsync(newOrder);
            await unitOfWork.SaveAsync();

            var notificationEvent = new NotificationEmailIntegrationEvent(order.UserEmail,
             $"Dear Customer,\n\n" +
             $"Your {order.OrderNumber} has been completed.\n" +
             $"Your order {order.Type},{order.MenuName},{order.Quantity} is delivered at {order.CreationDate.ToShortTimeString()} !!\n\n" +
             "Thank you for choosing us.\n" +
             "Have a nice day.\n\n" +
             "---- This is a notification email ----");
            eventBus.Publish(notificationEvent);

            return true;
        }
    }
}
