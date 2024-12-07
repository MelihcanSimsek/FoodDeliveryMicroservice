using MediatR;
using Microsoft.AspNetCore.Http;
using PaymentService.Application.Bases;
using PaymentService.Application.Extensions;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Payments.Queries.GetAllUserPaymentMethods
{
    public class GetAllUserPaymentMethodsQueryHandler : BaseHandler, IRequestHandler<GetAllUserPaymentMethodsQueryRequest, IList<GetAllUserPaymentMethodsQueryResponse>>
    {
        public GetAllUserPaymentMethodsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllUserPaymentMethodsQueryResponse>> Handle(GetAllUserPaymentMethodsQueryRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            IList<PaymentCard> paymentCards = await unitOfWork.GetReadRepository<PaymentCard>().GetAllAsync(p => p.UserId == userId);

            IList<GetAllUserPaymentMethodsQueryResponse> response = new List<GetAllUserPaymentMethodsQueryResponse>();

            foreach (var paymentCard in paymentCards)
            {
                response.Add(new() { Id = paymentCard.Id, LastFourDigits = "****"+ paymentCard.Number[^4..] });
            }

            return response;
        }
    }
}
