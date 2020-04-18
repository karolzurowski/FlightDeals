using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightDeals.Core.Models.FlightOffer;
using FlightDeals.Core.Models.FlightSearch;
using FlightDeals.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ibistic.Public.OpenAirportData;
using Ibistic.Public.OpenAirportData.OpenFlightsData;
using Ibistic.Public.OpenAirportData.MemoryDatabase;
using FlightDeals.Data.AirportProvider;
using FlightDeals.Data;
using FlightDeals.Core.Extensions;

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
        public async Task<IActionResult> Index(FlightSearchViewModel flightSearchViewModel)
        {
            if (ModelState.IsValid)
            {
                var flightsearchModel = mapper.Map<FlightSearchViewModel, FlightSearchModel>(flightSearchViewModel);

                var flightOffersJson = await flightOffersClient.GetFlightOffers(flightsearchModel);

                List<FlightOfferModel> offers = JsonConvert.DeserializeObject<List<FlightOfferModel>>(flightOffersJson, new JsonSerializerSettings { Formatting = Formatting.Indented });

                return View("FlightOffers", offers);
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