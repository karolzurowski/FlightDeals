using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class AdditionalServicesRequest
    {
        [JsonProperty("chargeableCheckedBags")]
        public IncludedCheckedBags ChargeableCheckedBags { get; set; }

        /// <summary>
        /// Seat number
        /// </summary>
        [JsonProperty("chargeableSeatNumber")]
        public string ChargeableSeatNumber { get; set; }
    }
}
