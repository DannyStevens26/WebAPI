using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.Models
{
    public class CompositeAccount
    {
        public Account Account { get; set; }
        public Addresses Address { get; set; }
    }
}
