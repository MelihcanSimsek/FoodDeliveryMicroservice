using MediatR;
using Microsoft.AspNetCore.Http;
using PaymentService.Application.Bases;
using PaymentService.Application.Extensions;
using PaymentService.Application.Features.Payments.Rules;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommandHandler : BaseHandler, IRequestHandler<DeletePaymentMethodCommandRequest, Unit>
    {
        private readonly PaymentRules paymentRules;
        public DeletePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, PaymentRules paymentRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.paymentRules = paymentRules;
        }

        public async Task<Unit> Handle(DeletePaymentMethodCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            PaymentCard card =  await unitOfWork.GetReadRepository<PaymentCard>().GetAsync(p=>p.Id == request.Id && p.UserId == userId);

            await paymentRules.ShouldPaymentMethodExists(card);

            await unitOfWork.GetWriteRepository<PaymentCard>().DeleteAsync(card);
            return Unit.Value;
        }
    }
}
