using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlightDeals.Core.Helpers
{
    /// <summary>
    /// Converting to/from ISO0861 datetime format
    /// </summary>
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact((string)reader.Value,"yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            var dateValue = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            writer.WriteValue(dateValue);
        }
    }
}
