using Newtonsoft.Json;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class AllotmentDetails
    {
        [JsonProperty("tourName")]
        public string TourName { get; set; }

        [JsonProperty("tourReference")]
        public string TourReference { get; set; }
    }
}
