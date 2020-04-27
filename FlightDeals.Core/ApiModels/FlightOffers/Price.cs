using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Total amount paid by the user
        /// </summary>
        [JsonProperty("total")]
        public float Total { get; set; }  

        /// <summary>
        ///  Amount without taxes
        /// </summary>
        [JsonProperty("base")]
        public float Base { get; set; } 

        /// <summary>
        /// List of applicable fees
        /// </summary>
        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }
    }
}

