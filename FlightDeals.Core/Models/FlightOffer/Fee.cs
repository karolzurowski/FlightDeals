using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class Fee
    {
        [JsonProperty("amount")]
        public string Amount { get; set; } //todo to float

        /// <summary>
        /// type of fee = ['TICKETING', 'FORM_OF_PAYMENT', 'SUPPLIER']
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } //todo change to enum
    }
}
