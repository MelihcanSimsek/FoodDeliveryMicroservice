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

namespace RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllPendingByBranchId
{
    public class GetAllPendingByBranchIdQueryHandler : BaseHandler , IRequestHandler<GetAllPendingByBranchIdQueryRequest, IList<GetAllPendingByBranchIdQueryResponse>>
    {
        public GetAllPendingByBranchIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllPendingByBranchIdQueryResponse>> Handle(GetAllPendingByBranchIdQueryRequest request, CancellationToken cancellationToken)
        {
            IList<OrderItem> orders = await unitOfWork.GetReadRepository<OrderItem>().GetAllAsync(p => p.BranchId == request.BranchId && p.Status == OrderStatus.PENDING);
            var response = mapper.Map<GetAllPendingByBranchIdQueryResponse, OrderItem>(orders);
            return response;
        }
    }
}
