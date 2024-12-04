using CourierService.Application.Bases;
using CourierService.Application.Extensions;
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

namespace CourierService.Application.Features.OrderItems.Queries.GetAllPendingOrder
{
    public class GetAllPendingOrderCommandHandler : BaseHandler, IRequestHandler<GetAllPendingOrderCommandRequest, IList<GetAllPendingOrderCommandResponse>>
    {
        public GetAllPendingOrderCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(unitOfWork, httpContextAccessor, mapper)
        {
        }

        public async Task<IList<GetAllPendingOrderCommandResponse>> Handle(GetAllPendingOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            IList<OrderItem> orderItemList = await unitOfWork.GetReadRepository<OrderItem>().GetAllAsync(p => p.OrderStatus == OrderStatus.PENDING);

            var response = mapper.Map<GetAllPendingOrderCommandResponse, OrderItem>(orderItemList);

            return response;
        }
    }
}
