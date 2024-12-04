using CourierService.Application.Bases;
using CourierService.Application.Features.Couriers.Rules;
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

namespace CourierService.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandHandler : BaseHandler,IRequestHandler<CreateCourierCommandRequest, Unit>
    {
        private readonly CourierRules courierRules;
        public CreateCourierCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, CourierRules courierRules) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.courierRules = courierRules;
        }

        public async Task<Unit> Handle(CreateCourierCommandRequest request, CancellationToken cancellationToken)
        {
            Courier? checkCourier = await unitOfWork.GetReadRepository<Courier>().GetAsync(p => p.UserId == request.UserId);
            await courierRules.ShouldCourierNotExists(checkCourier);

            Courier courier = mapper.Map<Courier, CreateCourierCommandRequest>(request);
            courier.Status = CourierStatus.OFFLINE;
            courier.IsWorking = true;
            await unitOfWork.GetWriteRepository<Courier>().AddAsync(courier);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
