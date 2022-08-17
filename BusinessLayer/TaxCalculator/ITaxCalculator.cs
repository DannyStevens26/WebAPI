using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer
{
    public interface ITaxCalculator
    {
        CountryTaxType countryTaxType { get; }

        void Calculate(OrderItem orderItem);
    }
}
