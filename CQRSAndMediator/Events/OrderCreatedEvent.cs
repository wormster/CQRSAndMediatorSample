using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSAndMediator.Events
{
    public class OrderCreatedEvent : INotification
    {
        public Guid OrderId { get; set; }

        public OrderCreatedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
