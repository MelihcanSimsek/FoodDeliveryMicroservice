using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Orders.IntegrationEvents.Events
{
    public class NotificationEmailIntegrationEvent : IntegrationEvent
    {
        public string Email { get; set; }
        public string Content { get; set; }

        public NotificationEmailIntegrationEvent(string email, string content)
        {
            Email = email;
            Content = content;
        }
    }
}
