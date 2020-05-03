using System;
using System.Collections.Generic;

namespace FlightDeals.Core.DomainModels.FlightOffers
{
    public class FlightOffer
    {
        public int Id { get; set; }

        public DateTime? LastTicketingDate { get; set; }

        public bool OneWay { get; set; }

        public int NumberOfBookableSeats { get; set; }

        public List<Itinerary> Itineraries { get; set; }

        public Price Price { get; set; }

        public List<TravelerPricing> TravelerPricings { get; set; }
    }
}
