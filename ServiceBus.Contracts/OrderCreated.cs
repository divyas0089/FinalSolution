﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.Contracts
{
    public class OrderCreated
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }
    }
}
