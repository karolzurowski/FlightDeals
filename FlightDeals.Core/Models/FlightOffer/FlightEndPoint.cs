using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class FlightEndPoint
    {
        /// <summary>
        /// IATA Airline code
        /// </summary>
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        /// <summary>
        /// Terminal name/number
        /// </summary>
        [JsonProperty("terminal")]
        public string Terminal { get; set; }

        /// <summary>
        ///  Local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        /// </summary>
        [JsonProperty("at")]
        public string At { get; set; }


    }
}
