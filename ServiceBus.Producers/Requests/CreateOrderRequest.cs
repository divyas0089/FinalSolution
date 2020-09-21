using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.Producers.Requests
{
    public class CreateOrderRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ProductName { get; set; }
    }
}
