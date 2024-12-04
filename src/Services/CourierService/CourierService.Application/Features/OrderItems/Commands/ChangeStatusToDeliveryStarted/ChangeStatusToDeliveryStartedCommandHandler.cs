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

namespace CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryStarted
{
    public class ChangeStatusToDeliveryStartedCommandHandler : BaseHandler, IRequestHandler<ChangeStatusToDeliveryStartedCommandRequest, Unit>
    {
        private readonly OrderItemRules orderItemRules;
        public ChangeStatusToDeliveryStartedCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, OrderItemRules orderItemRules) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.orderItemRules = orderItemRules;
        }

        public async Task<Unit> Handle(ChangeStatusToDeliveryStartedCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await unitOfWork.GetReadRepository<OrderItem>().GetAsync(p => p.OrderNumber == request.OrderNumber && p.CourierUserId == null);
            await orderItemRules.ShouldOrderItemExists(orderItem);

            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            orderItem.CourierUserId = courierUserId;
            orderItem.OrderStatus =OrderStatus.DELIVERY_STARTED;

            await unitOfWork.GetWriteRepository<OrderItem>().UpdateAsync(orderItem);
            await unitOfWork.SaveAsync();


            return Unit.Value;
        }
    }
}
