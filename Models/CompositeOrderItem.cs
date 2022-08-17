using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.Models
{
    public class CompositeOrderItem
    {
        public OrderItem OrderItem { get; set; }

        public Addresses Address { get; set; }

    }
}
