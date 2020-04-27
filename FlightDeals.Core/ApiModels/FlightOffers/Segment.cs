using FlightDeals.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class Segment
    {
        /// <summary>
        /// Id of the segment
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("departure")]
        public FlightEndPoint Departure { get; set; }

        [JsonProperty("arrival")]
        public FlightEndPoint Arrival { get; set; }

        /// <summary>
        /// The airline / carrier code 
        /// </summary>
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        /// <summary>
        /// The flight number as assigned by the carrier
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("operating")]
        public OperatingFlight Operating { get; set; }

        /// <summary>
        /// Stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M ,
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        [JsonProperty("duration",TypeNameHandling =TypeNameHandling.All)]
        public TimeSpan Duration { get; set; }  

        /// <summary>
        ///  Information regarding the different stops composing the flight segment. E.g. technical stop, change of gauge... ,
        /// </summary>
        [JsonProperty("stops")]
        public List<FlightStop> Stops { get; set; }

        

        /// <summary>
        /// Number of stops
        /// </summary>
        [JsonProperty("numberOfStops")]
        public int NumberOfStops { get; set; }
    }
    
    public class OperatingFlight
    {
        /// <summary>
        /// Providing the airline / carrier code
        /// </summary>
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }
    }
}
