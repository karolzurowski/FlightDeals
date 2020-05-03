using AutoMapper;
using Api = FlightDeals.Core.ApiModels;
using Domain = FlightDeals.Core.DomainModels;
using DomainFlightSearchModel = FlightDeals.Core.DomainModels.FlightSearch.FlightSearchModel;
using ApiFlightSearchModel = FlightDeals.Core.ApiModels.FlightSearch.FlightSearchModel;
using FlightDeals.Core.AirportProvider;

namespace FlightDeals.Core.Mappers
{
    public class FlightDealsMappingProfile : Profile
    {
        private readonly IAirportProvider airportProvider;

        public FlightDealsMappingProfile(IAirportProvider airportProvider)
        {
            this.airportProvider = airportProvider;
            
            CreateMap<DomainFlightSearchModel, ApiFlightSearchModel>()
                .ReverseMap();
          
            CreateMap<Api.FlightOffers.Price, Domain.FlightOffers.Price>();
          
            CreateMap<Api.TravelerType, Domain.TravelerType>();
           
            CreateMap<Api.TravelClass, Domain.TravelClass>();
          
            CreateMap<Api.FlightOffers.TravelerPricing, Domain.FlightOffers.TravelerPricing>();
           
            CreateMap<Api.FlightOffers.FareDetailsBySegment, Domain.FlightOffers.FareDetailsBySegment>().ForMember(dest => dest.TravelClass, opt => opt.MapFrom(src => src.Cabin)).ForMember(dest => dest.ReservationClass, opt => opt.MapFrom(src => src.Class));
          
            CreateMap<Api.FlightOffers.FlightEndPoint, Domain.FlightOffers.FlightEndPoint>().
                AfterMap((src, dest) =>
                {                   
                    dest.Airport = airportProvider.FindAirport(src.IataCode);                   
                });
          
            CreateMap<Api.FlightOffers.Itinerary, Domain.FlightOffers.Itinerary>();
          
            CreateMap<Api.FlightOffers.Segment, Domain.FlightOffers.Segment>().AfterMap((src, dest) =>
            {
                dest.FlightNumber = src?.CarrierCode + src?.Number;
            });
           
            CreateMap<Api.FlightOffers.FlightOffer, Domain.FlightOffers.FlightOffer>();
        }
    }
}
