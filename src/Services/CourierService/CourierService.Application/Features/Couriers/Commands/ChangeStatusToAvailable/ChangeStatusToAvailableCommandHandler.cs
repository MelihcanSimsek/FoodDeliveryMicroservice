using CourierService.Application.Bases;
using CourierService.Application.Extensions;
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

namespace CourierService.Application.Features.Couriers.Commands.ChangeStatusToAvailable
{
    public class ChangeStatusToAvailableCommandHandler : BaseHandler, IRequestHandler<ChangeStatusToAvailableCommandRequest, Unit>
    {
        private readonly CourierRules courierRules;
        public ChangeStatusToAvailableCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, CourierRules courierRules) : base(unitOfWork, httpContextAccessor, mapper)
        {
            this.courierRules = courierRules;
        }

        public async Task<Unit> Handle(ChangeStatusToAvailableCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            Courier? courier = await unitOfWork.GetReadRepository<Courier>().GetAsync(p => p.UserId == userId && !p.IsDeleted);

            await courierRules.ShouldCourierExists(courier);
            courier.Status = CourierStatus.AVAILABLE;

            await unitOfWork.GetWriteRepository<Courier>().UpdateAsync(courier);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
