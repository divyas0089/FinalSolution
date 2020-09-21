using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.Producers.Requests
{
    public class CreateCustomerRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
