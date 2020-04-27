using Newtonsoft.Json;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class Fee
    {
        [JsonProperty("amount")]
        public float Amount { get; set; } 

        /// <summary>
        /// type of fee = ['TICKETING', 'FORM_OF_PAYMENT', 'SUPPLIER']
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } //todo change to enum
    }
}
