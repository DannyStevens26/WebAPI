using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public interface ICreateOrderCommand
    {
        public IActionResult Create(OrderItem orderItem, Addresses address);
    }
}
