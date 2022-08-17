using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;
using System;

namespace OrdersOrganiser.BusinessLayer
{
    public class CheckOrderItem : ICheckOrderItem
    {
        private readonly OrderContext _context;
        public CheckOrderItem(OrderContext context)
        {
            _context = context;
        }
        public IActionResult Check(int id)
        {
            var orderItem = _context.OrderItems.Find(id);

            if (orderItem == null)
            {
                return new NotFoundResult();
            }

            var timeSinceOrder = (DateTime.Now - orderItem.DateOrdered).TotalDays;

            if (!orderItem.IsDelivered)
            {
                return new OkObjectResult($"Your order was received {Convert.ToInt32(Math.Floor(timeSinceOrder))} days ago.");
            }
            else
            {
                return new OkObjectResult($"Your order was delivered.");
            }
        }
    }
}
