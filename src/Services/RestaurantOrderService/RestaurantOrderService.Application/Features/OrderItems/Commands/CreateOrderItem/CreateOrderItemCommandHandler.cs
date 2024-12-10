using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantOrderService.Application.Bases;
using RestaurantOrderService.Application.Interfaces.CustomMapper;
using RestaurantOrderService.Application.Interfaces.UnitOfWorks;
using RestaurantOrderService.Domain.Entities;
using RestaurantOrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : BaseHandler, IRequestHandler<CreateOrderItemCommandRequest, Unit>
    {
        public CreateOrderItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem orderItem = mapper.Map<OrderItem, CreateOrderItemCommandRequest>(request);
            orderItem.Status = OrderStatus.PENDING;

            await unitOfWork.GetWriteRepository<OrderItem>().AddAsync(orderItem);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
