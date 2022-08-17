using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.TaxCalculator.TaxResolver
{
    public interface ITaxResolver
    {
        ITaxCalculator Resolve(CountryTaxType countryTaxType);
    }
}
