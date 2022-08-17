using System;
using System.Collections.Generic;

namespace OrdersOrganiser.Models
{
    public class CompositeProfile
    {
        public List<OrderItem> OrderItem { get; set; }
        public Addresses Address { get; set; }
        public Account Account { get; set; }
        public Guid AddressReference { set { AddressReference = Account.AddressReference; } }
    }
}
