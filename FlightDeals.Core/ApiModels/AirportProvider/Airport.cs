using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FlightDeals.Core.ApiModels.AirportProvider
{
    public class Airport
    {
        public Airport() { }

        public Airport(string name, string city, string country, string iataCode, int timeZoneUtcOffset)
        {
            Name = name;
            City = city;
            Country = country;
            IataCode = iataCode;
            TimeZoneUtcOffset = timeZoneUtcOffset;
        }
        
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string IataCode { get; set; }

        [Required]
        public int TimeZoneUtcOffset { get; set; }

        //indicates how many times users selected this airport
        [JsonIgnore]
        public int SelectionCounter { get; set; }

        public override string ToString()
        {
            return Name + ", " + City + ",  "+ Country;
        }
    }
}

