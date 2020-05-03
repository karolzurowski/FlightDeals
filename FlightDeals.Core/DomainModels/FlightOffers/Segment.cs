using FlightDeals.Core.ApiModels.AirportProvider;
using System;

namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class Segment
    {
        public FlightEndPoint Departure { get; set; }       

        public FlightEndPoint Arrival { get; set; }            

        public string FlightNumber { get; set; }

        /// <summary>
        /// Stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M ,
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
