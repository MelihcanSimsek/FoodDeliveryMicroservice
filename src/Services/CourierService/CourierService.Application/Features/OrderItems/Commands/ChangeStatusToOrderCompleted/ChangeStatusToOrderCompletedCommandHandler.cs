

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

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToOrderCompleted
{
    public class ChangeStatusToOrderCompletedCommandHandler : BaseHandler, IRequestHandler<ChangeStatusToOrderCompletedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        private readonly IEventBus eventBus;
        public ChangeStatusToOrderCompletedCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, OrderItemRules orderItemRules, IEventBus eventBus) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.orderItemRules = orderItemRules;
            this.eventBus = eventBus;
        }

        public async Task<Unit> Handle(ChangeStatusToOrderCompletedCommandRequest request, CancellationToken cancellationToken)
        {
            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.CourierUserId == courierUserId);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.OrderStatus = OrderStatus.ORDER_COMPLETED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            var orderCompletedEvent = new OrderCompletedIntegrationEvent(orderItem.OrderNumber);
            eventBus.Publish(orderCompletedEvent);

            return Unit.Value;
        }
    }
}
