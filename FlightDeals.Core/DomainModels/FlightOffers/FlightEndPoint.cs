using FlightDeals.Core.ApiModels.AirportProvider;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class FlightEndPoint
    {
      
        public Airport Airport { get; set; }

        /// <summary>
        /// Terminal name/number
        /// </summary>      
        public string Terminal { get; set; }

        /// <summary>
        ///  Local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        /// </summary>            
        public DateTime At { get; set; }
    }
}
