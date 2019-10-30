using FlightDeals.Core.Models.FlightSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightDeals.Services.Interfaces
{
    public interface IFlightOffersClient
    {
        Task<string> GetFlightOffers(FlightSearchModel flightOffersModel);
    }
}
