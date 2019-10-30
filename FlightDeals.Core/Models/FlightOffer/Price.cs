using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Total amount paid by the user
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }   //todo change to float

        /// <summary>
        ///  Amount without taxes
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }  //todo to float

        /// <summary>
        /// List of applicable fees
        /// </summary>
        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }
    }

}

