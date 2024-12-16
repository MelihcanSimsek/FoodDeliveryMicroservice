using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Bases;
using OrderService.Application.Features.Orders.IntegrationEvents.Events;
using OrderService.Application.Interfaces.CustomMapper;
using OrderService.Application.Interfaces.UnitOfWorks;
using OrderService.Domain.Entities;
using OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : BaseHandler, IRequestHandler<CreateOrderCommandRequest, bool>
    {
        private readonly IEventBus evenBus;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEventBus evenBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.evenBus = evenBus;
        }

        public async Task<bool> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            List<EventPaymentItem> eventPaymentItems = new List<EventPaymentItem>();
            foreach (var orderItem in request.EventOrderItems)
            {
                Order order = mapper.Map<Order, EventOrderItem>(orderItem);
                order.UserId = request.UserId;
                order.OrderNumber = Guid.NewGuid();
                order.Status = OrderStatus.ORDER_STARTED;

                await unitOfWork.GetWriteRepository<Order>().AddAsync(order);
                await unitOfWork.SaveAsync();

                eventPaymentItems.Add(new EventPaymentItem(order.OrderNumber, order.RestaurantId, order.BranchId,
                    order.MenuName, order.Type.ToString(), order.UnitPrice, order.Quantity, order.UserEmail,
                    order.Address, order.RestaurantAddress));
            }

            var orderCreatedEvent = new OrderCreatedIntegrationEvent(request.UserId,eventPaymentItems );
            evenBus.Publish(orderCreatedEvent);
            return true;
        }
    }
}
