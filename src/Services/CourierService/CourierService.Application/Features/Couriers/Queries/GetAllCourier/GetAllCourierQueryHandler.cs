using CourierService.Application.Bases;
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

namespace CourierService.Application.Features.Couriers.Queries.GetAllCourier
{
    public class GetAllCourierQueryHandler : BaseHandler, IRequestHandler<GetAllCourierQueryRequest, IList<GetAllCourierQueryResponse>>
    {
        public GetAllCourierQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(unitOfWork, httpContextAccessor, mapper)
        {
        }

        public async Task<IList<GetAllCourierQueryResponse>> Handle(GetAllCourierQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Courier> courierList = await unitOfWork.GetReadRepository<Courier>().GetAllAsync(p => !p.IsDeleted && p.IsWorking && p.Status == CourierStatus.AVAILABLE);
            var response = mapper.Map<GetAllCourierQueryResponse, Courier>(courierList);

            return response;
        }
    }
}
