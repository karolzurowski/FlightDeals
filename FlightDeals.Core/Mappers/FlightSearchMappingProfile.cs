using AutoMapper;
using DomainFlightSearchModel = FlightDeals.Core.DomainModels.FlightSearch.FlightSearchModel;
using ApiFlightSearchModel = FlightDeals.Core.ApiModels.FlightSearch.FlightSearchModel;

namespace FlightDeals.Core.Mappers
{
    public class FlightSearchMappingProfile:Profile
    {
        public FlightSearchMappingProfile()
        {
            CreateMap<DomainFlightSearchModel, ApiFlightSearchModel>()
                .ReverseMap();
        }
    }
}
