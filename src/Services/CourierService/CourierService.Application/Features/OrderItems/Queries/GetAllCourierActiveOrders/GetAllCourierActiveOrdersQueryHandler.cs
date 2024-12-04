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

namespace CourierService.Application.Features.OrderItems.Queries.GetAllCourierActiveOrders
{
    public class GetAllCourierActiveOrdersQueryHandler : BaseHandler , IRequestHandler<GetAllCourierActiveOrdersQueryRequest, IList<GetAllCourierActiveOrdersQueryResponse>>
    {
        public GetAllCourierActiveOrdersQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(unitOfWork, httpContextAccessor, mapper)
        {
        }

        public async Task<IList<GetAllCourierActiveOrdersQueryResponse>> Handle(GetAllCourierActiveOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            Guid courierUserId = httpContextAccessor.HttpContext.User.GetUserId();
            IList<OrderItem> orderItemList = await unitOfWork.GetReadRepository<OrderItem>().GetAllAsync(p => p.CourierUserId == courierUserId && p.OrderStatus == OrderStatus.DELIVERY_STARTED);
            var response = mapper.Map<GetAllCourierActiveOrdersQueryResponse, OrderItem>(orderItemList);

            return response;
        }
    }
}
