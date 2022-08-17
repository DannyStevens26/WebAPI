using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public interface ICreateAccountCommand
    {
        public IActionResult Create(Account account, Addresses addresses);
    }
}
