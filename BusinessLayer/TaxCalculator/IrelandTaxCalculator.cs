using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.TaxCalculator
{
    public class IrelandTaxCalculator : ITaxCalculator
    {
        public CountryTaxType countryTaxType => CountryTaxType.Ireland;

        public void Calculate(OrderItem orderItem)
        {
            switch (orderItem.TaxCatagory)
            {
                case TaxCatagory.Standard:
                    orderItem.TaxRate = 0.23;
                    break;
                case TaxCatagory.Reduced:
                    orderItem.TaxRate = 13.5;
                    break;
                case TaxCatagory.Zero:
                    orderItem.TaxRate = 0;
                    break;
            }
        }
    }
}
