using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Bases;
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
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = mapper.Map<Order, CreateOrderCommandRequest>(request);
            order.OrderNumber = Guid.NewGuid();
            order.Status = OrderStatus.ORDER_STARTED;

            await unitOfWork.GetWriteRepository<Order>().AddAsync(order);
            await unitOfWork.SaveAsync();

            var response = mapper.Map<CreateOrderCommandResponse, Order>(order);

            return response;
        }
    }
}
