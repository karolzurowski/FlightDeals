using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDeals.Core.Models.FlightOffer
{
    public class FareDetailsBySegment
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        /// <summary>
        /// Quality of service offered in the cabin where the seat is located in this flight.
        /// Economy, premium economy, business or first class = ['ECONOMY', 'PREMIUM_ECONOMY', 'BUSINESS', 'FIRST']
        /// </summary>
        [JsonProperty("cabin")]
        public string Cabin { get; set; } //todo change to enum

        /// <summary>
        /// Fare basis specifying the rules of a fare.Usually, though not always, is composed of the booking class code 
        /// followed by a set of letters and digits representing other characteristics of the ticket, such as refundability, 
        /// minimum stay requirements, discounts or special promotional elements.
        /// </summary>
        [JsonProperty("fareBasis")]
        public string FareBasis { get; set; }

        /// <summary>
        /// The name of the Fare Family corresponding to the fares.Only for AMADEUS and if airline has fare families filed
        /// </summary>
        [JsonProperty("brandedFare")]
        public string BrandedFare { get; set; }


        /// <summary>
        /// The code of the booking class, a.k.a. class of service or Reservations/Booking Designator(RBD)
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        ///  True if the corresponding booking class is in an allotment     
        /// </summary>
        [JsonProperty("isAllotment")]
        public bool IsAllotment { get; set; }

        [JsonProperty("allotmentDetails")]
        public AllotmentDetails AllotmentDetails { get; set; }

        /// <summary>
        ///  slice and Dice indicator, such as Local Availability, Sub OnD(Origin and Destination) 
        ///  1 Availability and Sub OnD 2 Availability = ['LOCAL_AVAILABILITY', 'SUB_OD_AVAILABILITY_1', 'SUB_OD_AVAILABILITY_2'],
        /// </summary>
        [JsonProperty("sliceDiceIndicator")]
        public string SliceDiceIndicator { get; set; }

        [JsonProperty("includedCheckedBags")]
        public IncludedCheckedBags IncludedCheckedBags { get; set; }

        [JsonProperty("additionalServices")]
        public AdditionalServicesRequest AdditionalServices { get; set; }
    }
}

