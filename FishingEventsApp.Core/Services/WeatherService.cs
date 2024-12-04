using FishingEvents.Infrastructure.Data.Models.WeatherModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Services
{
    public class WeatherService(HttpClient client, IConfiguration configuration, IMemoryCache memoryCache)
    {
        public async Task<Weather> GetWeatherAsync(string location)
        {
            // Check if data is already in the cache
            if (memoryCache.TryGetValue(location, out Weather cachedWeather))
            {
                return cachedWeather; // Return cached data
            }

            string? key = configuration["WeatherApiKey"];   //enter your API key here or paste in User Secrets.
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}?unitGroup=metric&include=alerts%2Ccurrent%2Cevents&key={key}&contentType=json";

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Weather? weatherData = JsonConvert.DeserializeObject<Weather>(json);

                if (weatherData != null)
                {
                    // Add the fetched data to the cache
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheExpirationMinutes) // Cache duration
                    };
                    memoryCache.Set(location, weatherData, cacheEntryOptions);

                    return weatherData;
                }

                throw new InvalidOperationException("Error deserializing weather data.");
            }
            else
            {
                throw new HttpRequestException("Error fetching weather data.");
            }
        }
    }
}
