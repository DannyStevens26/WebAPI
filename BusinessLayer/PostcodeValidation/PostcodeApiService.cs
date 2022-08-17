using Newtonsoft.Json;
using OrdersOrganiser.BusinessLayer.Exceptions;
using OrdersOrganiser.Models;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.PostcodeValidation
{
    public class PostcodeApiService : IPostcodeApiService
    {
        private readonly IPostcodeApiClient _postcodeApiClient;

        public PostcodeApiService(IPostcodeApiClient postcodeApiClient)
        {
            _postcodeApiClient = postcodeApiClient;
        }

        public async Task<PostcodeApiValidationResponse> ValidatePostcode(string postcode)
        {
            var response = await _postcodeApiClient.ValidatePostcode(postcode);

            if (response == null || !response.IsSuccessStatusCode)
            {
                throw new PostcodeApiServiceException("Postcode service not working");
            }

            var responseResult = JsonConvert.DeserializeObject<PostcodeApiValidationResponse>(
                await response.Content.ReadAsStringAsync());

            return responseResult;
        }
    }
}
