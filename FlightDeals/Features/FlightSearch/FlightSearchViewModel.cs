using FlightDeals.Core.DomainModels;
using FlightDeals.Core.DomainModels.FlightSearch;
using System;
using System.ComponentModel.DataAnnotations;


namespace FlightDeals.Features.FlightSearch
{
    public class FlightSearchViewModel
    {
        public FlightSearchModel FlightSearch { get; }

        public FlightSearchViewModel()
        {
            FlightSearch = new FlightSearchModel();
        }

        [Required(ErrorMessage = "Please select departure location")]
        public string OriginLocationCode
        {
            get { return FlightSearch.OriginLocationCode; }
            set { FlightSearch.OriginLocationCode = value; }
        }

        [Required(ErrorMessage = "Please select arrival location")]
        public string DestinationLocationCode
        {
            get { return FlightSearch.DestinationLocationCode; }
            set { FlightSearch.DestinationLocationCode = value; }
        }

        [Required(ErrorMessage = "Departure date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DepartureDate
        {
            get { return FlightSearch.DepartureDate; }
            set { FlightSearch.DepartureDate = value; }
        }

        public string ReturnDate
        {
            get { return FlightSearch.ReturnDate; }
            set { FlightSearch.ReturnDate = value; }
        }

        [Required(ErrorMessage = "Number of adults is required")]
        public int? Adults
        {
            get { return FlightSearch.Adults; }
            set { FlightSearch.Adults = value; }
        }

        public int? Children
        {
            get { return FlightSearch.Children; }
            set { FlightSearch.Children = value; }
        }
        public int? Infants
        {
            get { return FlightSearch.Infants; }
            set { FlightSearch.Infants = value; }
        }

        public TravelClass? TravelClass
        {
            get { return FlightSearch.TravelClass; }
            set { FlightSearch.TravelClass = value; }
        }

        public string IncludedAirlineCodes
        {
            get { return FlightSearch.IncludedAirlineCodes; }
            set { FlightSearch.IncludedAirlineCodes = value; }
        }

        public string ExcludedAirlineCodes
        {
            get { return FlightSearch.ExcludedAirlineCodes; }
            set { FlightSearch.ExcludedAirlineCodes = value; }
        }

        public bool NonStop
        {
            get { return FlightSearch.NonStop; }
            set { FlightSearch.NonStop = value; }
        }

        public string CurrencyCode
        {
            get { return FlightSearch.CurrencyCode; }
            set { FlightSearch.CurrencyCode = value; }
        }

        public int? Max
        {
            get { return FlightSearch.Max; }
            set { FlightSearch.Max = value; }
        }
    }
}
