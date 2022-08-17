using Newtonsoft.Json;

namespace OrdersOrganiser.Models
{
    public class PostcodeApiValidationResponse
    {
        [JsonProperty("result")]
        public bool PostcodeResult { get; set; }
    }
}
