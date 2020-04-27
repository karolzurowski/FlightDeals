using System;
using System.ComponentModel.DataAnnotations;

namespace FlightDeals.Core.DomainModels.FlightSearch
{
    public class FlightSearchModel
    {
        public FlightSearchModel() { }

        [Required(ErrorMessage = "Please select departure location")]
        public string OriginLocationCode { get; set; }

        [Required(ErrorMessage = "Please select arrival location")]
        public string DestinationLocationCode { get; set; }

        [Required(ErrorMessage = "Departure date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DepartureDate { get; set; }

        public string ReturnDate { get; set; }

        [Required(ErrorMessage = "Number of adults is required")]
        public int? Adults { get; set; }

        public int? Children { get; set; } = null;

        public int? Infants { get; set; } = null;

        public TravelClass? TravelClass { get; set; } = null;

        public string IncludedAirlineCodes { get; set; } = null;

        public string ExcludedAirlineCodes { get; set; } = null;

        public bool NonStop { get; set; }

        public string CurrencyCode { get; set; } = null;

        public int? Max { get; set; } = 100;
    }
}
