using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class AllotmentDetails
    {
        [JsonProperty("tourName")]
        public string TourName { get; set; }

        [JsonProperty("tourReference")]
        public string TourReference { get; set; }
    }
}
