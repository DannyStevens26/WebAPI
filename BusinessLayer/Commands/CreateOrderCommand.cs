using System;
using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.BusinessLayer.TaxCalculator.TaxResolver;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly OrderContext _context;
        private static int Id;
        private readonly ICreateAddressCommand _createAddressCommand;
        private readonly ITaxResolver _taxResolver;

        public CreateOrderCommand(OrderContext context, ICreateAddressCommand createAddressCommand, ITaxResolver taxResolver)
        {
            _context = context;
            _createAddressCommand = createAddressCommand;
            _taxResolver = taxResolver;
        }
        public IActionResult Create(OrderItem orderItem, Addresses address)
        {
            var addressResponse = _createAddressCommand.Create(address);

            Id++;

            orderItem.Id = Id;

            orderItem.DateOrdered = DateTime.Now;

            orderItem.IsDelivered = false;

            orderItem.AddressReference = addressResponse;

            var taxCalculator = _taxResolver.Resolve(address.CountryTaxType);

            taxCalculator.Calculate(orderItem);

            _context.OrderItems.Add(orderItem);

            _context.SaveChanges();

            return new OkObjectResult($"Your order number is {orderItem.Id} \r We received your order at {orderItem.DateOrdered}, your postcode is {address.Postcode}");

        }
    }
}
