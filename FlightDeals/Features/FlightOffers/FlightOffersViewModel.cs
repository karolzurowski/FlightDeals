using FlightDeals.Core.DomainModels.FlightOffers;
using System.Collections.Generic;

namespace FlightDeals.Features.FlightOffers
{
    public class FlightOffersViewModel
    {
        public FlightOffersViewModel(List<FlightOffer> flightOffers)
        {
            FlightOffers = flightOffers;
        }

        public List<FlightOffer> FlightOffers { get; }
    }
}
