using OrdersOrganiser.BusinessLayer.PostcodeValidation;

namespace OrdersOrganiser.BusinessLayer
{
    public class ValidatePostcodeCommand : IValidatePostcodeCommand
    {
        private readonly IPostcodeApiService _postcodeApiService;

        public ValidatePostcodeCommand(IPostcodeApiService postcodeApiService)
        {
            _postcodeApiService = postcodeApiService;
        }
        
        public bool Execute(string postcode)
        {
            var response = _postcodeApiService.ValidatePostcode(postcode);

            return response.Result.PostcodeResult;
        }
    }
}
