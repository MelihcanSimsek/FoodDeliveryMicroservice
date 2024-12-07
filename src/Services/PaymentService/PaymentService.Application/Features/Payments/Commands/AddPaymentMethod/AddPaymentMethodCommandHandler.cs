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

namespace PaymentService.Application.Features.Payments.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandHandler : BaseHandler, IRequestHandler<AddPaymentMethodCommandRequest, Unit>
    {
        private readonly PaymentRules paymentRules;
        public AddPaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, PaymentRules paymentRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.paymentRules = paymentRules;
        }

        public async Task<Unit> Handle(AddPaymentMethodCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            PaymentCard? checkPaymentCard = await unitOfWork.GetReadRepository<PaymentCard>().GetAsync(p => p.UserId == userId && p.Name == request.CardName && p.Number == request.CardNumber && p.CCV == request.CCV);

            await paymentRules.ShouldPaymentMethodCanNotBeDuplicate(checkPaymentCard);

            PaymentCard paymentCard = new()
            {
                ExpiryDate = request.ExpiryDate,
                CCV = request.CCV,
                Name = request.CardName,
                Number = request.CardNumber,
                Type = request.Type,
                UserId = userId
            };

            await unitOfWork.GetWriteRepository<PaymentCard>().AddAsync(paymentCard);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
