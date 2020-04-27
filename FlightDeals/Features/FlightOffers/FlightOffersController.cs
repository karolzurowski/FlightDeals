using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDeals.Core.ApiModels.FlightOffers;
using FlightDeals.Features.FlightOffers;
using Microsoft.AspNetCore.Mvc;

namespace FlightDeals.Features.FlightOffers
{
    public class FlightOffersController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }
    }
}