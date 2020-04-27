using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightDeals.Core.ApiModels.FlightOffers;
using FlightDeals.Core.ApiModels.FlightSearch;
using FlightDeals.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FlightDeals.Data.AirportProvider;
using FlightDeals.Data;
using FlightDeals.Core.Extensions;
using DomainFlightSearchModel = FlightDeals.Core.DomainModels.FlightSearch.FlightSearchModel;

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

                var offers = JsonConvert.DeserializeObject<List<FlightOfferModel>>(flightOffersJson, new JsonSerializerSettings { Formatting = Formatting.Indented });

                return View("../FlightOffers/Index", offers);


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