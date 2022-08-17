using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersOrganiser.Models
{
    public class Addresses
    {
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Postcode { get; set; }
        [Key]
        public Guid AddressReference { get; set; }
        public CountryTaxType CountryTaxType { get; set; }
    }
}
