using CourierService.Application.Bases;
using CourierService.Application.Extensions;
using CourierService.Application.Features.OrderItems.Rules;
using CourierService.Application.Interfaces.CustomMapper;
using CourierService.Application.Interfaces.UnitOfWorks;
using CourierService.Domain.Entites;
using CourierService.Domain.Enums;
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
        public ChangeStatusToDeliveryFailedCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, OrderItemRules orderItemRules) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.orderItemRules = orderItemRules;
        }

        public async Task<Unit> Handle(ChangeStatusToDeliveryFailedCommandRequest request, CancellationToken cancellationToken)
        {
            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.CourierUserId == courierUserId);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            orderItem.OrderStatus = OrderStatus.DELIVERY_FAILED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();


            return Unit.Value;
        }
    }
}
