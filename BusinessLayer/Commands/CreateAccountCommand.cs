using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly OrderContext _context;
        private static int Id;
        private readonly ICreateAddressCommand _createAddressCommand;

        public CreateAccountCommand(OrderContext context, ICreateAddressCommand createAddressCommand)
        {
            _context = context;
            _createAddressCommand = createAddressCommand;
        }

        public IActionResult Create(Account account, Addresses addresses)
        {
            var addressResponse = _createAddressCommand.Create(addresses);

            Id++;

            account.Id = Id;

            account.AddressReference = addressResponse;

            account.IsVerified = false;

            _context.Accounts.Add(account);

            _context.SaveChanges();

            return new OkObjectResult($"Your account has been create successfully {account.FirstName}. Your id is {Id}.");
        }
    }
}
