using Newtonsoft.Json;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class Tax
    {
        [JsonProperty("amount")]
        public string Amount { get; set; } // todo to float

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
