using FlightDeals.Core.ApiModels.AirportProvider;
using System;

namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class Segment
    {
        public Airport Departure { get; set; }

        public string DepartureTerminal { get; set; }

        /// <summary>
        ///  Local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        /// </summary>
        public DateTime DepartureAt { get; set; }

        public Airport Arrival { get; set; }

        public string ArrivalTerminal { get; set; }

        /// <summary>
        ///  Local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        /// </summary>
        public DateTime ArrivalAt { get; set; }

        public string CarrierCode { get; set; }

        public string FlightNumber { get; set; }

        /// <summary>
        /// Stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M ,
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
