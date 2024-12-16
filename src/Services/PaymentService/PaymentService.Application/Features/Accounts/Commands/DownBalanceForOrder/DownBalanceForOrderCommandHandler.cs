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

            try
            {
                await unitOfWork.BeginTransactionAsync();
                Account account = await unitOfWork.GetReadRepository<Account>().GetAsync(p => p.UserId == request.UserId);
                foreach (var paymentItem in request.EventPaymentItems)
                {
                    account.Balance = account.Balance - (paymentItem.UnitPrice * paymentItem.Quantity);
                }
                await unitOfWork.GetWriteRepository<Account>().UpdateAsync(account);
                await unitOfWork.SaveAsync();
                await unitOfWork.CommitTransactionAsync();

                foreach (var paymentItem in request.EventPaymentItems)
                {
                    var paymentSuccessIntegrationEvent = new PaymentSuccessIntegrationEvent(request.UserId, paymentItem.RestaurantId,
                    paymentItem.BranchId, paymentItem.OrderNumber, paymentItem.MenuName,
                    paymentItem.UnitPrice, paymentItem.Quantity, paymentItem.UserEmail,
                    paymentItem.Address, paymentItem.RestaurantAddress);
                    eventBus.Publish(paymentSuccessIntegrationEvent);
                }
                
                return true;
            }
            catch (Exception)
            {
                await unitOfWork.RollbackTransactionAsync();
                foreach (var paymentItem in request.EventPaymentItems)
                {
                    var orderFailedEventForPaymentFailed = new OrderFailedIntegrationEvent(paymentItem.OrderNumber,
                    "An error occurred during checkout, so the order is being cancelled.");
                    eventBus.Publish(orderFailedEventForPaymentFailed);
                }
                return true;
            }

        }
    }
}
