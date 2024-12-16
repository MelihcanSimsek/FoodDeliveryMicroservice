using MediatR;
using Microsoft.AspNetCore.Http;
using PaymentService.Application.Bases;
using PaymentService.Application.Extensions;
using PaymentService.Application.Features.Accounts.Rules;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.FakePayments;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.AddBalanceWithMethod
{
    public class AddBalanceWithMethodCommandHandler : BaseHandler, IRequestHandler<AddBalanceWithMethodCommandRequest, Unit>
    {
        private readonly AccountRules accountRules;
        private readonly IPaymentService paymentService;
        public AddBalanceWithMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, AccountRules accountRules, IPaymentService paymentService) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.accountRules = accountRules;
            this.paymentService = paymentService;
        }

        public async Task<Unit> Handle(AddBalanceWithMethodCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();

            Account? account = await unitOfWork.GetReadRepository<Account>().GetAsync(p => p.UserId == userId);
            await accountRules.ShouldAccountExists(account);

            PaymentCard paymentCard = new PaymentCard()
            {
                Name=request.CardName,
                CCV=request.CCV,
                ExpiryDate=request.ExpiryDate,
                Type=request.Type,
                Number=request.CardNumber,
            };

            await accountRules.ShouldCardValid(await paymentService.CheckCardValid(paymentCard));
            await accountRules.ShouldPaymentSuccess(await paymentService.TakePayment(paymentCard, request.Amount));

            account.Balance = account.Balance + request.Amount;
            await unitOfWork.GetWriteRepository<Account>().UpdateAsync(account);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
