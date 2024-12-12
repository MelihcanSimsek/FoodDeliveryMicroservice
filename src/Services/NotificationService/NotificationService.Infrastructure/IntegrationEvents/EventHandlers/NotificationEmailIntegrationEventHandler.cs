using EventBus.Base.Abstraction;
using NotificationService.Infrastructure.IntegrationEvents.Events;
using NotificationService.Infrastructure.MailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.IntegrationEvents.EventHandlers
{
    public class NotificationEmailIntegrationEventHandler : IIntegrationEventHandler<NotificationEmailIntegrationEvent>
    {
        private readonly IMailService mailService;

        public NotificationEmailIntegrationEventHandler(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public Task Handle(NotificationEmailIntegrationEvent @event)
        {
            this.mailService.SendMail(@event.Email, @event.Content);
            return Task.CompletedTask;
        }
    }
}
