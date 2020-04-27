using System.Collections.Generic;

namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class TravelerPricing
    {
        public string TravelerId { get; set; }

        /// <summary>
        /// Traveler type age restrictions : CHILD < 12y, INFANT < 2y, SENIOR >=60 = ['ADULT', 'CHILD', 'SENIOR', 'YOUNG', 'HELD_INFANT', 'SEATED_INFANT', 'STUDENT'],
        /// </summary>     
        public TravelerType TravelerType { get; set; }  
        public Price Price { get; set; }
        public List<FareDetailsBySegment> FareDetailsBySegment { get; set; }

    }
}
