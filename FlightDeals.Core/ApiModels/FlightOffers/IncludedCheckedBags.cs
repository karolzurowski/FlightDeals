using Newtonsoft.Json;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class IncludedCheckedBags
    {
        /// <summary>
        /// Total number of units
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Weight of the baggage allowance
        /// </summary>
        [JsonProperty("weight")]
        public int Weigth { get; set; }

        /// <summary>
        /// Code to qualify unit as pounds or kilos
        /// </summary>
        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }
    }
}
