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

namespace RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllAcceptedByBranchId
{
    public class GetAllAcceptedByBranchIdQueryHandler : BaseHandler, IRequestHandler<GetAllAcceptedByBranchIdQueryRequest, IList<GetAllAcceptedByBranchIdQueryResponse>>
    {
        public GetAllAcceptedByBranchIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllAcceptedByBranchIdQueryResponse>> Handle(GetAllAcceptedByBranchIdQueryRequest request, CancellationToken cancellationToken)
        {
            IList<OrderItem> orders = await unitOfWork.GetReadRepository<OrderItem>().GetAllAsync(p => p.BranchId == request.BranchId && p.Status == OrderStatus.ACCEPTED);
            var response = mapper.Map<GetAllAcceptedByBranchIdQueryResponse, OrderItem>(orders);
            return response;
        }
    }
}
