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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Commands.UpBalanceForOrder
{
    public class UpBalanceForOrderCommandHandler : BaseHandler, IRequestHandler<UpBalanceForOrderCommandRequest, bool>
    {
        private readonly IEventBus eventBus;
        public UpBalanceForOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEventBus eventBus) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.eventBus = eventBus;
        }

        public async Task<bool> Handle(UpBalanceForOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                Account account = await unitOfWork.GetReadRepository<Account>().GetAsync(p => p.UserId == request.UserId);
                account.Balance = account.Balance + (request.UnitPrice * request.Quantity);

                await unitOfWork.GetWriteRepository<Account>().UpdateAsync(account);
                await unitOfWork.SaveAsync();
                await unitOfWork.CommitTransactionAsync();

                var orderFailedEvent = new OrderFailedIntegrationEvent(request.OrderNumber, request.FailMessage);
                eventBus.Publish(orderFailedEvent);
                return true;
            }
            catch (Exception)
            {
                await unitOfWork.RollbackTransactionAsync();
                if (request.Type == typeof(RestaurantRejectedIntegrationEvent))
                {
                    var integrationEvent = new RestaurantRejectedIntegrationEvent(request.UserId,
                        request.OrderNumber, request.UnitPrice, request.Quantity, request.UserEmail,
                        request.FailMessage);
                    eventBus.Publish(integrationEvent);

                }
                else if (request.Type == typeof(DeliveryFailedIntegrationEvent))
                {
                    var integrationEvent = new DeliveryFailedIntegrationEvent(request.UserId,
                       request.OrderNumber, request.UnitPrice, request.Quantity, request.UserEmail,
                       request.FailMessage);
                    eventBus.Publish(integrationEvent);
                }

                return false;
            }
        }
    }
}
