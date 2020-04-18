using FlightDeals.Core.Extensions;
using FlightDeals.Core.Models.AirportProvider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlightDeals.Data.AirportProvider
{
    public class AirportProvider : IAirportProvider
    {
        private readonly string airportsFile;

        public AirportProvider()
        {
            LoadJsonAirportFile();        
        }
        public List<Airport> Airports { get; private set; } = new List<Airport>();
        private void LoadJsonAirportFile()
        {
            string line;
            string[] properties;
            string airportName;
            string cityName;
            string countryName;
            string iataCode;

            var file = new StreamReader(@"airports.cache");
            while ((line = file.ReadLine()) != null)
            {
                line = line.Replace("\"", "");
                properties = line.Split(',');

                airportName = properties[1];
                cityName = properties[2];
                countryName = properties[3];
                iataCode = properties[4];
                int.TryParse(properties[9], out int timeZoneUtcOffset);

                if (!string.IsNullOrEmpty(airportName) && !string.IsNullOrEmpty(cityName)
                    && !string.IsNullOrEmpty(countryName) && !string.IsNullOrEmpty(iataCode))
                {
                    Airports.Add(new Airport(airportName, cityName, countryName, iataCode, timeZoneUtcOffset));
                }
            }
        }
        public IEnumerable<Airport> FindAirports(string contains, int fetchLimit)
        {
            var comparison = StringComparison.InvariantCultureIgnoreCase;
            return Airports.Where(a => a.IataCode.Contains(contains, comparison)
                                                         || a.Name.Contains(contains, comparison)
                                                         || a.City.Contains(contains, comparison))
                                                         //  || a.Country.StartsWith(contains,copmarison))
                                                         .OrderByDescending(a => a.SelectionCounter)
                                                         .Take(fetchLimit);
        }
    }
}
