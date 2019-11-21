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

namespace FlightDeals.Features.FlightSearch
{
    public class FlightSearchController : Controller
    {
        private readonly IFlightOffersClient flightOffersClient;
        private readonly IMapper mapper;

        public FlightSearchController(IFlightOffersClient flightOffersClient, IMapper mapper)
        {
            this.flightOffersClient = flightOffersClient;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FlightSearchViewModel flightSearchViewModel)
        {
            var flightsearchModel = mapper.Map<FlightSearchViewModel, FlightSearchModel>(flightSearchViewModel);

            var flightOffersJson = await flightOffersClient.GetFlightOffers(flightsearchModel);

            List<FlightOfferModel> offers = JsonConvert.DeserializeObject<List<FlightOfferModel>>(flightOffersJson,new JsonSerializerSettings {Formatting=Formatting.Indented });

            return View();
        }
    }
}