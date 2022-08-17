using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }
    }
}
