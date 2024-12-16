using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.IntegrationEvents.Events
{
    public class UserCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }

        public UserCreatedIntegrationEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
