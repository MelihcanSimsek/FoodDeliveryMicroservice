using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantOrderService.Application.Bases;
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

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToCompleted
{
    public class ChangeOrderStatusToCompletedCommandHandler : BaseHandler, IRequestHandler<ChangeOrderStatusToCompletedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        public ChangeOrderStatusToCompletedCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, OrderItemRules orderItemRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.orderItemRules = orderItemRules;
        }

        public async Task<Unit> Handle(ChangeOrderStatusToCompletedCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.Status = OrderStatus.COMPLETED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();

            // this is a event line for delivery service
            
            return Unit.Value;
        }
    }
}
