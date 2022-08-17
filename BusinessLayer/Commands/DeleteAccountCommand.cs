using System.Linq;
using System.Threading.Tasks;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class DeleteAccountCommand : IDeleteCommand
    {
        private readonly OrderContext _context;

        public DeleteAccountCommand(OrderContext context)
        {
            _context = context;
        }
        public DeleteType deleteType => DeleteType.Account;
        public async Task Execute(int id)
        {

            var account = await _context.Accounts.FindAsync(id);

            _context.Accounts.Remove(account);

            if (!_context.OrderItems.Any(order => order.AddressReference == account.AddressReference))
            {
                var address = await _context.Addresses.FindAsync(account.AddressReference);

                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
        }
    }
}
