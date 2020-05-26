
using FlightDeals.Core.Extensions;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightDeals.Services
{
    public class TypedClientBase : HttpClient
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HttpClient Client { get; }

        public TypedClientBase(HttpClient client)
        {
            Client = client;
        }

        public async Task<string> GetAsync(string uri, string token, string parametersJson)
        {
            if (string.IsNullOrEmpty(parametersJson))
            {
                throw new ArgumentException(
                   "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nParameters cannot be null or empty");
            }

            var parametersDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersJson);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = AttachUriParameters(new Uri(uri, UriKind.Relative), parametersDict)
            };

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = (await Client.SendAsync(httpRequestMessage));

            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string uri, Dictionary<string, string> data,
                                                     Dictionary<string, string> headers = null)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException(
                   "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nData cannot be null or empty");
            }
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

            var response = (await Client.SendAsync(httpRequestMessage));

            await response.EnsureSuccessStatusCodeAsync();
            return await response.Content.ReadAsStringAsync();
        }
        
        public Uri AttachUriParameters(Uri uri, Dictionary<string, string> parameters)
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

        #region NOT_USED
        // public async Task<string> GetAsync(string uri,
        //                                      Dictionary<string, string> parameters,
        //                                       Dictionary<string, string> headers = null)
        //{
        //    var httpRequestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = AttachUriParameters(new Uri(uri, UriKind.Relative), parameters)
        //    };

        //    if (headers != null)
        //    {
        //        foreach (var kvp in headers.Where(kvp => kvp.Value != null))
        //        {
        //            httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
        //        }
        //    }

        //    var response = (await Client.SendAsync(httpRequestMessage));
        //    var responseContent = await response.Content.ReadAsStringAsync();

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return responseContent;
        //    }
        //    else
        //    {
        //        logger.Error($"Request : {httpRequestMessage} \n resulted in\n {responseContent} ");
        //        return null;
        //    }
        //}


        //public async Task<string> PostAsync(string uri, string data,
        //                                             Dictionary<string, string> headers = null)
        //{
        //    var httpRequestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(uri, UriKind.Relative),
        //        Content = new StringContent(data),
        //    };

        //    if (headers != null)
        //    {
        //        foreach (var kvp in headers.Where(kvp => kvp.Value != null))
        //        {
        //            httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
        //        }
        //    }

        //    var response = (await Client.SendAsync(httpRequestMessage));

        //    await response.EnsureSuccessStatusCodeAsync();
        //    return await response.Content.ReadAsStringAsync();
        //}


        //public async Task<string> PostAsync(string uri, string dataJson,
        //                                       string headersJson = null)
        //{
        //    if (string.IsNullOrEmpty(dataJson))
        //    {
        //        throw new ArgumentException(
        //           "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nData cannot be null or empty");
        //    }

        //    var dataDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataJson);
        //    var httpRequestMessage = new HttpRequestMessage
        //    {

        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(uri, UriKind.Relative),
        //        Content = new FormUrlEncodedContent(dataDict),
        //    };

        //    if (String.IsNullOrEmpty(headersJson))
        //    {
        //        var headersDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(headersJson);
        //        foreach (var kvp in headersDict.Where(kvp => kvp.Value != null))
        //        {
        //            httpRequestMessage.Headers.Add(kvp.Key, kvp.Value);
        //        }
        //    }

        //    var response = (await Client.SendAsync(httpRequestMessage));

        //    await response.EnsureSuccessStatusCodeAsync();
        //    return await response.Content.ReadAsStringAsync();
        //}
        #endregion
    }
}
