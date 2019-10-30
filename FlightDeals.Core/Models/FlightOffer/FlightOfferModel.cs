using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public  partial class FlightOfferModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Source of the flight offer = ['GDS', 'PYTON']
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// If true, inform that a ticketing will be required at booking step
        /// </summary>
        [JsonProperty("instantTicketingRequired")]
        public bool InstantTicketingRequired { get; set; }

        /// <summary>
        /// If true, inform that a ticketing will be required at booking step
        /// </summary>
        [JsonProperty("disablePricing")]
        public bool DisablePricing { get; set; }

        /// <summary>
        /// If true, upon completion of the booking, this pricing solution is expected to yield multiple records
        /// (a record contains booking information confirmed and stored, typically a Passenger Name Record (PNR), in the provider GDS or system) 
        /// </summary>
        [JsonProperty("nonHomogeneous")]
        public bool NonHomogeneous { get; set; }

        /// <summary>
        /// If true, the flight offer is one itinerary to fulfill one of origin and destination areas, and a pricing solution to describe the fare breakdown and conditions involved
        /// </summary>
        [JsonProperty("oneWay")]
        public bool OneWay { get; set; }

        /// <summary>
        /// If true, a payment card is mandatory to book this flight offer
        /// </summary>
        [JsonProperty("paymentCardRequired")]
        public bool PaymentCardRequired { get; set; }

        /// <summary>
        ///  If booked on the same day as the search (with respect to timezone), this flight offer is guaranteed to be thereafter valid for ticketing until this date (included). 
        ///  Unspecified when it does not make sense for this flight offer (e.g. no control over ticketing once booked) 
        /// </summary>
        [JsonProperty("lastTicketingDate")]
        public DateTime? LastTicketingDate { get; set; }

        /// <summary>
        /// Number of seats bookable in a single request. Can not be higher than 9
        /// </summary>
        [JsonProperty("numberOfBookableSeats")]
        public int NumberOfBookableSeats { get; set; }

        [JsonProperty("itineraries")]
        public List<Itinerary> Itineraries { get; set; }




      
    }
}
