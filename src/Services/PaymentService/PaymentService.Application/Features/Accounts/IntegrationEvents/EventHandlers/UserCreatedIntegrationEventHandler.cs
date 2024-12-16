using EventBus.Base.Abstraction;
using MediatR;
using PaymentService.Application.Features.Accounts.Commands.CreateAccount;
using PaymentService.Application.Features.Accounts.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.EventHandlers
{
    public class UserCreatedIntegrationEventHandler : IIntegrationEventHandler<UserCreatedIntegrationEvent>
    {
        private readonly IMediator mediator;

        public UserCreatedIntegrationEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Handle(UserCreatedIntegrationEvent @event)
        {
            var request = new CreateAccountCommandRequest()
            {
                UserId = @event.UserId
            };

            await mediator.Send(request);
        }
    }
}
