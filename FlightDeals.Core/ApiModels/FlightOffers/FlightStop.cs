using Newtonsoft.Json;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class FlightStop  //todo change string to dateformats
    {
        /// <summary>
        /// IATA airline codes
        /// </summary>
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        /// <summary>
        /// Stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g.PT2H10M 
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Arrival at the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00 ,
        /// </summary>
        [JsonProperty("arrivalAt")]
        public string ArrivalAt { get; set; }

        /// <summary>
        ///  Departure from the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        /// </summary>
        [JsonProperty("departureAt")]
        public string DepartureAt { get; set; }
    }
}
