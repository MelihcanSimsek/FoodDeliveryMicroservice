using CourierService.Application.Bases;
using CourierService.Application.Interfaces.CustomMapper;
using CourierService.Application.Interfaces.UnitOfWorks;
using CourierService.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : BaseHandler, IRequestHandler<CreateOrderItemCommandRequest, bool>
    {
        public CreateOrderItemCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(unitOfWork, httpContextAccessor, mapper)
        {
        }

        public async Task<bool> Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
        {
            OrderItem item = mapper.Map<OrderItem, CreateOrderItemCommandRequest>(request);
            await unitOfWork.GetWriteRepository<OrderItem>().AddAsync(item);
            await unitOfWork.SaveAsync();

            return true;
        }
    }
}
