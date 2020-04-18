using FlightDeals.Core.Extensions;
using FlightDeals.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FlightDeals.Core.Models.FlightSearch;
using Newtonsoft.Json.Linq;

namespace FlightDeals.Services
{
    public class FlightOffersClient : IFlightOffersClient
    {
        private DateTime tokenExpiration;
        private string token;
        private readonly HttpClient client;
        private readonly IConfiguration configuration;      

        public FlightOffersClient(HttpClient client, IConfiguration configuration)
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
            //using user-secrets
            var client_id = configuration["Authentication:client_id"];
            var client_secret = configuration["Authentication:client_secret"];

            var credentials = new Dictionary<string, string>()
            {
                { "grant_type","client_credentials" },
                { "client_id",client_id},
                { "client_secret",client_secret }
            };

            var uri = configuration.GetSection("Urls").GetSection("FlightOffersSearch").GetSection("Authorization").Value;
            var responseJson = await client.PostAsync(uri, credentials);
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseJson);
            response.TryGetValue("access_token", out token);
            response.TryGetValue("expires_in", out string expiresIn);
            tokenExpiration = DateTime.Now.AddSeconds(Int32.Parse(expiresIn));
        }

        public async Task<string> GetFlightOffers(FlightSearchModel flightOffersModel)
        {
            await UpdateToken();
          
            Dictionary<string, string> modelDict = flightOffersModel.ToDictionary();
            var json = JsonConvert.SerializeObject(flightOffersModel, Formatting.Indented,
                                                   new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            var uri = configuration.GetSection("Urls").GetSection("FlightOffersSearch").GetSection("Api").Value;
            var jsonResponse = await client.GetAsync(uri, token, json);
            return JObject.Parse(jsonResponse)["data"].ToString();
        }
    }
}
