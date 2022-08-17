using OrdersOrganiser.Models;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.PostcodeValidation
{
    public interface IPostcodeApiService
    {
        Task<PostcodeApiValidationResponse> ValidatePostcode(string postcode);
    }
}
