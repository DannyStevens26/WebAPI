using System;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer
{
    public interface ICreateAddressCommand
    {
        public Guid Create(Addresses address);
    }
}
