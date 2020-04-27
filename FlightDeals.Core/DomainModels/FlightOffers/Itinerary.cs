using System;
using System.Collections.Generic;

namespace FlightDeals.Core.DomainModels.FlightOffers

{
    public class Itinerary
    {
        /// <summary>
        /// Duration in ISO8601 PnYnMnDTnHnMnS format, e.g. PT2H10M 
        /// </summary>
        public TimeSpan Duration { get; set; }

        public List<Segment> Segments { get; set; }      
    }
}
