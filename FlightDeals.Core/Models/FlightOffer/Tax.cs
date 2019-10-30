using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class Tax
    {
        [JsonProperty("amount")]
        public string Amount { get; set; } // todo to float

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
