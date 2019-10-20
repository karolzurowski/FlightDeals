using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightDeals.Core.Models;
using FlightDeals.Services.Interfaces;

namespace FlightDeals.Features.Home
{
    public class HomeController : Controller        
    {
        private readonly IFlightOffersSearchClient flightOffers;

        public HomeController(IFlightOffersSearchClient flightOffers)
        {
            this.flightOffers = flightOffers;
        }
        public IActionResult Index()
        {
            var result = flightOffers.GetFlightOffers().Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
