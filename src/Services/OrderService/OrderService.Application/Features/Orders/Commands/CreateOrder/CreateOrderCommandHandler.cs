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
    public class CreateOrderCommandHandler : BaseHandler, IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IEventBus evenBus;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEventBus evenBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.evenBus = evenBus;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = mapper.Map<Order, CreateOrderCommandRequest>(request);
            order.OrderNumber = Guid.NewGuid();
            order.Status = OrderStatus.ORDER_STARTED;

            await unitOfWork.GetWriteRepository<Order>().AddAsync(order);
            await unitOfWork.SaveAsync();

            var response = mapper.Map<CreateOrderCommandResponse, Order>(order);
         
            var orderCreatedEvent = new OrderCreatedIntegrationEvent(order.UserId, order.RestaurantId,
                order.BranchId, order.OrderNumber, order.MenuName, order.UnitPrice, order.Quantity,
                order.UserEmail, order.Address, order.RestaurantAddress);
            evenBus.Publish(orderCreatedEvent);

            return response;
        }
    }
}
