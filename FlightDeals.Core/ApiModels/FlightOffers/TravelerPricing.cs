using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightDeals.Core.ApiModels.FlightOffers
{
    public class TravelerPricing
    {
        [JsonProperty("travelerId")]
        public string TravelerId { get; set; }

        /// <summary>
        /// Option specifying a group of fares, which may be valid under certain conditons 
        /// Can be used to specify special fare discount for a passenger = ['STANDARD', 'INCLUSIVE_TOUR', 'SPANISH_MELILLA_RESIDENT', 'SPANISH_CEUTA_RESIDENT',
        /// 'SPANISH_CANARY_RESIDENT', 'SPANISH_BALEARIC_RESIDENT', 'AIR_FRANCE_METROPOLITAN_DISCOUNT_PASS', 'AIR_FRANCE_DOM_DISCOUNT_PASS', 'AIR_FRANCE_COMBINED_DISCOUNT_PASS', 
        /// 'AIR_FRANCE_FAMILY', 'ADULT_WITH_COMPANION', 'COMPANION'],
        /// </summary>
        [JsonProperty("fareOption")]
        public string FareOption { get; set; } //todo to enum

        /// <summary>
        /// Traveler type age restrictions : CHILD < 12y, INFANT < 2y, SENIOR >=60 = ['ADULT', 'CHILD', 'SENIOR', 'YOUNG', 'HELD_INFANT', 'SEATED_INFANT', 'STUDENT'],
        /// </summary>
        [JsonProperty("travelerType")]
        public TravelerType TravelerType { get; set; }  //todo to enum

        /// <summary>
        /// If type="INFANT", correspond to the adult travelers's id who will share the seat 
        /// </summary>
        [JsonProperty("associatedAdultId")]
        public string AssociatedAdultId { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("fareDetailsBySegment")]
        public List<FareDetailsBySegment >FareDetailsBySegment { get; set; }        
    }
}
