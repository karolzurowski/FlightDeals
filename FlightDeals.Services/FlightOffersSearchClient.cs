using FlightDeals.Core.Extensions;
using FlightDeals.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace FlightDeals.Services
{
    public class FlightOffersSearchClient : IFlightOffersSearchClient
    {
        private DateTime tokenExpiration;
        private string token;
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public FlightOffersSearchClient(HttpClient client,IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }

        private async Task<string> UpdateToken()
        {
            if (DateTime.Now > tokenExpiration)
            {
                await GetToken();
            }
            return token;
        }

        private async Task GetToken()
        {
            //todo read this from cfg file
            var credentials = new Dictionary<string, string>()
            {
                { "grant_type","client_credentials" },
                { "client_id","pji5a33tciu3l5SdDkHRhy7ffxGfqHBX"},
                { "client_secret","yKKvmrOnLVK49tVX" }
            };

            var uri = configuration.GetSection("Urls").GetSection("FlightOffersSearch").GetSection("Authorization").Value;

            var responseJson = await client.PostAsync(uri, credentials);
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseJson);


            response.TryGetValue("access_token", out token);
            response.TryGetValue("expires_in", out string expiresIn);
            tokenExpiration = DateTime.Now.AddSeconds(Int32.Parse(expiresIn));
        }

        public async Task<string> GetFlightOffers()
        {
            await UpdateToken();
            var uri = configuration.GetSection("Urls").GetSection("FlightOffersSearch").GetSection("Api").Value;

            var parameters = new Dictionary<string, string>()
            {
                {"originLocationCode","KRK" },
                { "destinationLocationCode","PAR" },
                {"departureDate","2019-12-25" },
                { "adults","1"}
            };
            return await client.GetAsync(uri, token, parameters);
        }


       
    }
}
