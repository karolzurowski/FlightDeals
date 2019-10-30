using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class Itinerary
    {
        /// <summary>
        /// Duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M 
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }  //todo change this to datetime


        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }

       
    }

}