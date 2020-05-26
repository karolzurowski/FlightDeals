using System;
using System.Net;

namespace FlightDeals.Core.Extensions
{
    public class SimpleHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public SimpleHttpResponseException(HttpStatusCode statusCode, string content) : base(content)
        {
            StatusCode = statusCode;
        }  
    }
}