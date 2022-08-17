using System;
using System.Linq;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer
{
    public class CreateAddressCommand : ICreateAddressCommand
    {
        private readonly OrderContext _context;
        private readonly IValidatePostcodeCommand _addressChecker;

        public CreateAddressCommand(OrderContext context, IValidatePostcodeCommand addressChecker)
        {
            _context = context;
            _addressChecker = addressChecker;
        }

        public Guid Create(Addresses address)
        {
            if (!_addressChecker.Execute((address.Postcode)))
            {
                throw new PostcodeNotFoundException("Postcode not valid.");
            }

            if (_context.Addresses.Where(e => e.Postcode == address.Postcode)
                .Any(e => e.HouseNumber == address.HouseNumber))
            {
                var existingAddress1 = _context.Addresses
                    .Where(a => a.Postcode == address.Postcode)
                    .First(a => a.HouseNumber == address.HouseNumber);

                address.AddressReference = existingAddress1.AddressReference;
            }
            else
            {
                address.AddressReference = Guid.NewGuid();

                _context.Addresses.Add(address);

                _context.SaveChanges();
            }

            return address.AddressReference;
        }
    }
}
