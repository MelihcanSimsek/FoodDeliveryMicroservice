using MediatR;
using Microsoft.AspNetCore.Http;
using PaymentService.Application.Bases;
using PaymentService.Application.Extensions;
using PaymentService.Application.Features.Accounts.Rules;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.CheckBalanceForOrder
{
    public class CheckBalanceForOrderCommandHandler : BaseHandler, IRequestHandler<CheckBalanceForOrderCommandRequest, Unit>
    {
        private readonly AccountRules accountRules;
        public CheckBalanceForOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, AccountRules accountRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.accountRules = accountRules;
        }

        public async Task<Unit> Handle(CheckBalanceForOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            Account? account = await unitOfWork.GetReadRepository<Account>().GetAsync(p => p.UserId == userId);
            await accountRules.ShouldAccountExists(account);
            await accountRules.ShouldAccountBalanceEnoughForOrderPrice(account, request.TotalAmount);

            return Unit.Value;
        }
    }
}
