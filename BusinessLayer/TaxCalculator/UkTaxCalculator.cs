using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer
{
    public class UkTaxCalculator : ITaxCalculator
    {
        public CountryTaxType countryTaxType => CountryTaxType.UK;

        public void Calculate(OrderItem orderItem)
        {
            switch (orderItem.TaxCatagory)
            {
                case TaxCatagory.Standard:
                    orderItem.TaxRate = 0.20;
                    break;
                case TaxCatagory.Reduced:
                    orderItem.TaxRate = 0.05;
                    break;
                case TaxCatagory.Zero:
                    orderItem.TaxRate = 0;
                    break;
            }
        }
    }
}
