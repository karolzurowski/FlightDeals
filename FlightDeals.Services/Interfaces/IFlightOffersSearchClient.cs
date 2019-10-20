using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightDeals.Services.Interfaces
{
    public interface IFlightOffersSearchClient
    {
        Task<string> GetFlightOffers();
    }
}
