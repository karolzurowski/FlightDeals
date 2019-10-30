using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static FlightDeals.Core.Models.FlightSearch.Enumerations;

namespace FlightDeals.Features.FlightSearch
{
    public class FlightSearchViewModel
    {
        [Required(ErrorMessage ="Origin location code is required")]
        public string OriginLocationCode { get; set; }

        [Required(ErrorMessage ="DestinationLocationCode is required")]
        public string DestinationLocationCode { get; set; }

        [Required(ErrorMessage ="DepartureDate is required")]
        public string DepartureDate { get; set; }

        public string ReturnDate { get; set; }

        [Required(ErrorMessage ="Number of adults is required")]
        public int? Adults { get; set; }

        public int? Children { get; set; } = null;

        public int? Infants { get; set; } = null;


        public TravelClass? TravelClass { get; set; } = null;


        public string IncludedAirlineCodes { get; set; } = null;


        public string ExcludedAirlineCodes { get; set; } = null;


        public bool NonStop { get; set; }


        public string CurrencyCode { get; set; } = null;


        public int? Max { get; set; } = 10;
    }
}
