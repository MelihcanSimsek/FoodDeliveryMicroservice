using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using PaymentService.Application.Bases;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using PaymentService.Application.Interfaces.CustomMapper;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.UpdateBalanceForOrder
{
    public class DownBalanceForOrderCommandHandler : BaseHandler, IRequestHandler<DownBalanceForOrderCommandRequest, bool>
    {
        private readonly IEventBus eventBus;
        public DownBalanceForOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEventBus eventBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.eventBus = eventBus;
        }

        public async Task<bool> Handle(DownBalanceForOrderCommandRequest request, CancellationToken cancellationToken)
        {

            await unitOfWork.BeginTransactionAsync();
            try
            {
                Account account = await unitOfWork.GetReadRepository<Account>().GetAsync(p => p.UserId == request.UserId);
                account.Balance = account.Balance - (request.UnitPrice * request.Quantity);

                await unitOfWork.GetWriteRepository<Account>().UpdateAsync(account);
                await unitOfWork.SaveAsync();
                await unitOfWork.CommitTransactionAsync();

                var paymentSuccessIntegrationEvent = new PaymentSuccessIntegrationEvent(request.UserId, request.RestaurantId,
                    request.BranchId, request.OrderNumber, request.MenuName,
                    request.UnitPrice, request.Quantity, request.UserEmail,
                    request.Address, request.RestaurantAddress);
                eventBus.Publish(paymentSuccessIntegrationEvent);
                return true;
            }
            catch (Exception)
            {
                await unitOfWork.RollbackTransactionAsync();
                var orderFailedEventForPaymentFailed = new OrderFailedIntegrationEvent(request.OrderNumber,
                    "An error occurred during checkout, so the order is being cancelled.");
                eventBus.Publish(orderFailedEventForPaymentFailed);
                return true;
            }

        }
    }
}
