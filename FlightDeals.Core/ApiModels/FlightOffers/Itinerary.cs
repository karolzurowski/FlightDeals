using FlightDeals.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class Itinerary
    {
        /// <summary>
        /// Duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M 
        /// </summary>
        [JsonConverter(typeof(TimeSpanConverter))]
        [JsonProperty( PropertyName ="duration",TypeNameHandling =TypeNameHandling.All)]
        public TimeSpan Duration { get; set; } 

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }     
    }

}