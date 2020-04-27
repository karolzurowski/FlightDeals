using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightDeals.Core.ApiModels;
using FlightDeals.Services.Interfaces;

namespace FlightDeals.Features.Home
{
    public class HomeController : Controller        
    {
        private readonly IFlightOffersClient flightOffers;

        public HomeController(IFlightOffersClient flightOffers)
        {
            this.flightOffers = flightOffers;
        }
        public IActionResult Index()
        {            
           // var result = flightOffers.GetFlightOffers(new FlightOffersModel()).Result;
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
