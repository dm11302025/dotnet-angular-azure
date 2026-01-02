using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Events
{
    public class OrderCreatedEvent : BaseEvent
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }

        public OrderCreatedEvent()
        {
            EventType = "OrderCreated";
        }
    }

}
