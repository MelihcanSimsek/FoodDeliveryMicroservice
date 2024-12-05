using MediatR;
using Microsoft.AspNetCore.Http;
using OrderService.Application.Bases;
using OrderService.Application.Extensions;
using OrderService.Application.Interfaces.CustomMapper;
using OrderService.Application.Interfaces.UnitOfWorks;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.Queries.GetAllUserOrders
{
    public class GetAllUserOrdersQueryHandler : BaseHandler, IRequestHandler<GetAllUserOrdersQueryRequest, IList<GetAllUserOrdersQueryResponse>>
    {
        public GetAllUserOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllUserOrdersQueryResponse>> Handle(GetAllUserOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            IList<Order> orders = await unitOfWork.GetReadRepository<Order>()
                .GetAllByPagingAsync(p=>p.UserId == userId,
                sort:c=>c.OrderByDescending(f=>f.CreationDate),
                currentPage:request.Page,pageSize:request.Size);

            var response = mapper.Map<GetAllUserOrdersQueryResponse, Order>(orders);
            return response;
        }
    }
}
