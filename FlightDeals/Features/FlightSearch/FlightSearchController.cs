using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FlightDeals.Core.ApiModels.FlightOffers;
using FlightDeals.Core.ApiModels.FlightSearch;
using FlightDeals.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FlightDeals.Core.AirportProvider;
using FlightDeals.Data;
using FlightDeals.Core.Extensions;
using DomainFlightSearchModel = FlightDeals.Core.DomainModels.FlightSearch.FlightSearchModel;
using DomainFlightOffersModel = FlightDeals.Core.DomainModels.FlightOffers.FlightOffer;
using FlightDeals.Features.FlightOffers;

namespace FlightDeals.Features.FlightSearch
{
    public class FlightSearchController : Controller
    {
        private readonly IFlightOffersClient flightOffersClient;
        private readonly IMapper mapper;
        private readonly FlightDealsContext context;
        private readonly IAirportProvider airportProvider;

        public FlightSearchController(IFlightOffersClient flightOffersClient, IMapper mapper, FlightDealsContext context, IAirportProvider airportProvider)
        {
            this.flightOffersClient = flightOffersClient;
            this.mapper = mapper;
            this.context = context;
            this.airportProvider = airportProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchForFlights(FlightSearchViewModel flightSearchViewModel)
        {
            if (ModelState.IsValid)
            {
                var flightsearchModel = mapper.Map<DomainFlightSearchModel, FlightSearchModel>(flightSearchViewModel.FlightSearch);

                var flightOffersJson = await flightOffersClient.GetFlightOffers(flightsearchModel);

                var apiFlightOffers = JsonConvert.DeserializeObject<List<FlightOffer>>(flightOffersJson, new JsonSerializerSettings { Formatting = Formatting.Indented });

                var domainFlightOffers = mapper.Map<List<FlightOffer>, List<DomainFlightOffersModel>>(apiFlightOffers);

                var flightOffersViewModel = new FlightOffersViewModel(domainFlightOffers);

                return View("../FlightOffers/Index", flightOffersViewModel); 
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var airports = airportProvider.FindAirports(term).ConvertToJson();
                return Ok(airports);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}