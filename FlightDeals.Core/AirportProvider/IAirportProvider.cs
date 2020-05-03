using FlightDeals.Core.ApiModels.AirportProvider;
using System.Collections.Generic;

namespace FlightDeals.Core.AirportProvider
{
    public interface IAirportProvider
    {
        List<Airport> Airports { get; }
        IEnumerable<Airport> FindAirports(string contains, int returnLimit=10);
        Airport FindAirport(string iataCode);
    }
}