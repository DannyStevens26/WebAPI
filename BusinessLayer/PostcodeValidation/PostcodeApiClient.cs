using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.PostcodeValidation
{
    public class PostcodeApiClient : IPostcodeApiClient
    {
        private const string ApiRoute = "https://api.postcodes.io/postcodes";

        private static HttpClient _httpClient;

        public PostcodeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> ValidatePostcode(string postcode)
        {
            var uri = new Uri($"{ApiRoute}/{postcode}/validate");

            var response = await _httpClient.GetAsync(uri);

            return response;
        }
    }
}
