using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrdersOrganiser.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime DateOrdered { get; set; }
        public Guid AddressReference { get; set; }
        public TaxCatagory TaxCatagory { get; set; }
        public double TaxRate { get; set; }
    }
}
