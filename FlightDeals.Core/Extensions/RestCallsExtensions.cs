using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlightDeals.Core.Extensions
{
    public static class RestCallsExtensions
    {
        public static async Task<string> GetAsync(this HttpClient client, string uri,
                                                  Dictionary<string, string> parameters,
                                                  Dictionary<string, string> headers = null)
        {

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative).AttachParameters(parameters)
            };

            if (headers != null)
            {
                foreach (var kvp in headers.Where(kvp => kvp.Value != null))
                {
                    httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
                }
            }

            var response = (await client.SendAsync(httpRequestMessage)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public static async Task<string> GetAsync(this HttpClient client, string uri, string token, Dictionary<string, string> parameters)
        {

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri, UriKind.Relative).AttachParameters(parameters)                
            };

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);         

            var response = (await client.SendAsync(httpRequestMessage)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostAsync(this HttpClient client, string uri, Dictionary<string, string> data,
                                                     Dictionary<string, string> headers = null)
        {
            var httpRequestMessage = new HttpRequestMessage
            {

                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new FormUrlEncodedContent(data),
            };

            if (headers != null)
            {
                foreach (var kvp in headers.Where(kvp => kvp.Value != null))
                {
                    httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
                }
            }

            var response = (await client.SendAsync(httpRequestMessage)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }



        public static async Task<string> PostAsync(this HttpClient client, string uri, string data,
                                                       Dictionary<string, string> headers = null)
        {
            var httpRequestMessage = new HttpRequestMessage
            {

                Method = HttpMethod.Post,
                RequestUri = new Uri(uri, UriKind.Relative),
                Content = new StringContent(data),
            };

            if (headers != null)
            {
                foreach (var kvp in headers.Where(kvp => kvp.Value != null))
                {
                    httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
                }
            }

            var response = (await client.SendAsync(httpRequestMessage)).EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static Uri AttachParameters(this Uri uri, Dictionary<string, string> parameters)
        {
            if (!parameters.Any())
                return uri;

            var builder = new StringBuilder(uri.ToString() + "?");

            var separator = "";
            foreach (var kvp in parameters.Where(kvp => kvp.Value != null))
            {
                builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));

                separator = "&";
            }

            var uriWithParams = builder.ToString();

            return new Uri(uriWithParams, uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);

        }

        public static Dictionary<string,string> ToDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                dictionary.Add(property.Name, property.GetValue(obj).ToString());
            }

            return dictionary;
            
        }
    }
}


//var httpRequestMessage = new HttpRequestMessage
//{
//    Method = HttpMethod.Post,
//    RequestUri = new Uri("https://api.clickatell.com/rest/message"),
//    Headers = {
//                { HttpRequestHeader.Authorization.ToString(), "Bearer xxxxxxxxxxxxxxxxxxxx" },
//                { HttpRequestHeader.Access.ToString(), "application/json" },
//                { "X-Version", "1" }
//            },
//    Content = new StringContent(JsonConvert.SerializeObject(svm))
//};