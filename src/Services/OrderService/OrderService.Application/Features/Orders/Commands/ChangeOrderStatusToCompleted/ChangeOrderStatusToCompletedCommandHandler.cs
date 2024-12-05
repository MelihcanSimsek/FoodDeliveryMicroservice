using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Bases;
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
        public ChangeOrderStatusToCompletedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, OrderRules orderRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.orderRules = orderRules;
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

            return true;
        }
    }
}
