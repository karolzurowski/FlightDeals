using FlightDeals.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Globalization;



namespace FlightDeals.Core.Models.FlightSearch
{
    public class FlightSearchModel
    {
        private DateTime? departureDate = null;
        private DateTime? returnDate = null;

        /// <summary>
        /// City/airport IATA code from which the traveler will depart, REQUIRED
        /// </summary>
        [JsonProperty("originLocationCode")]
        public string OriginLocationCode { get; set; }

        /// <summary>
        /// City/airport IATA code to which the traveler is going, REQUIRED
        /// </summary>
        [JsonProperty("destinationLocationCode")]
        public string DestinationLocationCode { get; set; }

        /// <summary>
        /// The date on which the traveler will depart from the origin to go to the destination,REQUIRED
        /// Throws argument exception when string does not contain valid date
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty(PropertyName = "departureDate", TypeNameHandling = TypeNameHandling.All)]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// The date on which the traveler will depart from the destination to return to the origin. 
        /// If this parameter is not specified, only one-way itineraries are found. 
        /// If this parameter is specified, only round-trip itineraries are found.
        /// </summary>
        [JsonProperty("returnDate")]
        public string ReturnDate
        {
            get { return returnDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); }
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    returnDate = date;
                }
                else
                {
                    returnDate = null;
                }
            }
        }


        /// <summary>
        /// The number of adult travelers (age 12 or older on date of departure), REQUIRED
        /// </summary>
        [JsonProperty("adults")]
        public int? Adults { get; set; }

        /// <summary>
        /// The number of child travelers(older than age 2 and younger than age 12 on date of departure) who will each have their own separate seat.       
        /// </summary>
        [JsonProperty("children")]
        public int? Children { get; set; } = null;

        /// <summary>
        /// the number of infant travelers (whose age is less or equal to 2 on date of departure). 
        /// Infants travel on the lap of an adult traveler, and thus the number of infants must not exceed the number of adults
        /// </summary>
        [JsonProperty("infants")]
        public int? Infants { get; set; } = null;

        /// <summary>
        /// The accepted travel class is economy, premium economy, business or first class. If no travel class is specified, the search considers any travel class
        /// </summary>
        [JsonProperty("travelClass")]
        public TravelClass? TravelClass { get; set; } = null;

        /// <summary>
        /// If specified, the flight offer will include at least one segment per bound marketed by one of these airlines.
        /// Airlines are specified as IATA airline codes and are comma-separated, e.g. 6X,7X,8X
        /// </summary>
        [JsonProperty("includedAirlineCodes")]
        public string IncludedAirlineCodes { get; set; } = null;

        /// <summary>
        /// if specified, the flight offer will exclude all the flights marketed by one of these airlines. 
        /// Airlines are specified as IATA airline codes and are comma-separated, e.g. 6X,7X,8X
        /// </summary>
        [JsonProperty("excludedAirlineCodes")]
        public string ExcludedAirlineCodes { get; set; } = null;

        /// <summary>
        /// If set to true, the search will find only flights going from the origin to the destination with no stop in between
        /// </summary>
        [JsonProperty("nonStop")]
        public bool NonStop { get; set; }

        /// <summary>
        /// The preferred currency for the flight offers. Currency is specified in the ISO 4217 format, e.g. EUR for Euro
        /// </summary>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; } = null;

        /// <summary>
        /// Maximum number of flight offers to return. If specified, the value should be greater than or equal to 1
        /// </summary>
        [JsonProperty("max")]
        public int? Max { get; set; } = null;




    }
}
