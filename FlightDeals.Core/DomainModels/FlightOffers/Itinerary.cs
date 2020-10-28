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

        public string DurationString
        {
            get
            {
                return String.Format("{0}h{1}m", Duration.Days * 24 + Duration.Hours, Duration.Minutes);
            }
        }

        public List<Segment> Segments { get; set; }

        public int? Stops
        {
            get
            {
                return Segments.Count > 1 ? Segments.Count - 1 : (int?)null;
            }
        }
    }
}
