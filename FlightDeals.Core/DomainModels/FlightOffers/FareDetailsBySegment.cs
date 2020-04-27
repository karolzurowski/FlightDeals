
namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class FareDetailsBySegment
    {      
        public string SegmentId { get; set; }

        /// <summary>
        /// Quality of service offered in the cabin where the seat is located in this flight.
        /// Economy, premium economy, business or first class = ['ECONOMY', 'PREMIUM_ECONOMY', 'BUSINESS', 'FIRST']
        /// </summary>      
        public TravelClass TravelClass { get; set; } 

        /// <summary>
        /// The code of the booking class, a.k.a. class of service or Reservations/Booking Designator(RBD)
        /// </summary>    
        public string ReservationClass { get; set; }      
      
        //public IncludedCheckedBags IncludedCheckedBags { get; set; }
    }
}
