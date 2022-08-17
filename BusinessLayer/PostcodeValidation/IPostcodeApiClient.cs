using System.Net.Http;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.PostcodeValidation
{
    public interface IPostcodeApiClient
    {
        Task<HttpResponseMessage> ValidatePostcode(string postcode);
    }
}
