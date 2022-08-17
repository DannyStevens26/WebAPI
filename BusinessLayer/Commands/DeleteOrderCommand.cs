using System.Linq;
using System.Threading.Tasks;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class DeleteOrderCommand : IDeleteCommand
    {
        private readonly OrderContext _context;

        public DeleteOrderCommand(OrderContext context)
        {
            _context = context;
        }

        public DeleteType deleteType => DeleteType.Order;
        public async Task Execute(int id)
        {
            var order = await _context.OrderItems.FindAsync(id);

            _context.OrderItems.Remove(order);

            if (!_context.Accounts.Any(acc => acc.AddressReference == order.AddressReference))
            {
                var address = await _context.Addresses.FindAsync(order.AddressReference);

                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
        }
    }
}
