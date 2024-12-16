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

namespace PaymentService.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : BaseHandler, IRequestHandler<CreateAccountCommandRequest, bool>
    {
        private readonly AccountRules accountRules;
        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, AccountRules accountRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.accountRules = accountRules;
        }

        public async Task<bool> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            Account account = new Account()
            {
                UserId = request.UserId,
                LastUpdateDate = DateTime.Now
            };

            await unitOfWork.GetWriteRepository<Account>().AddAsync(account);
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
