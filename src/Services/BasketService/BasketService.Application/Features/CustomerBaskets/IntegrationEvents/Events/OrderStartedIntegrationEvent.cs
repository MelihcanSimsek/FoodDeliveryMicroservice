﻿using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.IntegrationEvents.Events
{
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public List<EvenOrderItem> EvenOrderItems { get; set; }
        public OrderStartedIntegrationEvent(Guid userId, List<EvenOrderItem> evenOrderItems)
        {
            UserId = userId;
            EvenOrderItems = evenOrderItems;
        }
    }
}

