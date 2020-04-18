using FlightDeals.Core.Models.AirportProvider;
using System.Collections.Generic;

namespace FlightDeals.Data.AirportProvider
{
    public interface IAirportProvider
    {
        List<Airport> Airports { get; }
        IEnumerable<Airport> FindAirports(string contains, int returnLimit=10);
    }
}