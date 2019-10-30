using AutoMapper;
using FlightDeals.Core.Models.FlightSearch;
using FlightDeals.Features.FlightSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightDeals
{
    public class FlightSearchMappingProfile:Profile
    {
        public FlightSearchMappingProfile()
        {
            CreateMap<FlightSearchViewModel, FlightSearchModel>()
                .ReverseMap();
        }
    }
}
