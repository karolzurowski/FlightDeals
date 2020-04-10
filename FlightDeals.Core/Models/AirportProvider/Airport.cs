﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightDeals.Core.Models.AirportProvider
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
        public int SelectionCounter { get; set; }

    }
}

