using FlightDeals.Core.Extensions;
using FlightDeals.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FlightDeals.Core.ApiModels.FlightSearch;
using Newtonsoft.Json.Linq;
using NLog;

namespace FlightDeals.Services
{
    public class FlightOffersClient : TypedClientBase, IFlightOffersClient
    {
        private DateTime tokenExpiration;
        private string token;
        private readonly HttpClient client;
        private readonly IConfiguration configuration;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public FlightOffersClient(HttpClient client, IConfiguration configuration) : base(client)
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
            var responseJson = await PostAsync(uri, credentials);
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseJson);

            response.TryGetValue("access_token", out token);
            response.TryGetValue("expires_in", out string expiresIn);
            tokenExpiration = DateTime.Now.AddSeconds(Int32.Parse(expiresIn));
        }

        public async Task<string> GetFlightOffers(FlightSearchModel flightSearchModel)
        {
            string jsonResponse = string.Empty;
            string response;
            try
            {
                await UpdateToken();

                Dictionary<string, string> modelDict = flightSearchModel.ToDictionary();
                var json = JsonConvert.SerializeObject(flightSearchModel, Formatting.Indented,
                                                       new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                var uri = configuration.GetSection("Urls").GetSection("FlightOffersSearch").GetSection("Api").Value;
                jsonResponse = await GetAsync(uri, token, json);

                response = JObject.Parse(jsonResponse)["data"].ToString();
            }
            catch (JsonReaderException ex)
            {
                logger.Error(ex, $"Error during parse operation to JObject,data : {Environment.NewLine}{jsonResponse}");
                throw new InvalidOperationException("Error during parse operation to JObject", ex);
            }
            return response;
        }
    }
}
