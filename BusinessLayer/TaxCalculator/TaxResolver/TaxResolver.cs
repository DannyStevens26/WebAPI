using System.Collections.Generic;
using System.Linq;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.TaxCalculator.TaxResolver
{
    public class TaxResolver :ITaxResolver
    {
        private readonly IEnumerable<ITaxCalculator> _taxCalculators;

        public TaxResolver(IEnumerable<ITaxCalculator> taxCalculators)
        {
            _taxCalculators = taxCalculators;
        }
        public ITaxCalculator Resolve(CountryTaxType countryTaxType)
        {
            return _taxCalculators.FirstOrDefault(x => x.countryTaxType == countryTaxType);
        }
    }
}
