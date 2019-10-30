using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightDeals.Core.Models.FlightSearch;
using Microsoft.AspNetCore.Mvc;

namespace FlightDeals.Features.FlightSearch
{
    public class FlightSearchController : Controller
    {
        private readonly IMapper mapper;

        public FlightSearchController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index (FlightSearchViewModel flightSearch)
        {
            var model = mapper.Map<FlightSearchViewModel, FlightSearchModel>(flightSearch);


  
            return View();
        }
    }
}