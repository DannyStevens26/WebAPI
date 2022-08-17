using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer
{
    public class PostcodeNotFoundException : Exception
    {
        public PostcodeNotFoundException(string message) : base(message)
        {
        }

    }
}
