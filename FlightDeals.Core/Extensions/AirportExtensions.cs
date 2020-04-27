using FlightDeals.Core.ApiModels.AirportProvider;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FlightDeals.Core.Extensions
{
    public static class AirportExtensions
    {
        public static string ConvertToJson(this IEnumerable<Airport> airports)
        {
            var jAirports = new JArray();
            foreach (var airport in airports)
            {
                jAirports.Add(JObject.FromObject(airport));
               
            }            
            return jAirports.ToString();
        }
    }
}
