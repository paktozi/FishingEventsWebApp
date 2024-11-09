using FishingEvents.Infrastructure.Data.Models.WeatherModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FishingEventsApp.Core.Services
{
    public class WeatherService(HttpClient client, IConfiguration configuration)
    {
        public async Task<Weather> GetWeatherAsync(string location)
        {
            string? key = configuration["WeatherApiKey"];
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{location}?unitGroup=metric&include=alerts%2Ccurrent%2Cevents&key={key}&contentType=json";

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Weather? weatherData = JsonConvert.DeserializeObject<Weather>(json);
                return weatherData;
            }
            else
            {
                throw new HttpRequestException("Error fetching weather data.");
            }
        }
    }
}
