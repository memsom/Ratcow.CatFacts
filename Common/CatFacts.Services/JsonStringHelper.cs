using System;
using System.Text.Json;

namespace CatFacts.Services
{
    public static class JsonStringHelper
    {
        public static T Deserialize<T>(this string data)
        {
            if (!string.IsNullOrWhiteSpace(data))
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    return JsonSerializer.Deserialize<T>(data, options);
                }
                catch (Exception)
                {
                    // TODO - log error
                }
            }

            return default;
        }
    }
}

