using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Models.WeatherModels
{
    public class CurrentConditions
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
        public string DateTime { get; set; } = string.Empty;
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public string Conditions { get; set; } = string.Empty;
        public string Cloudcover { get; set; } = string.Empty;
        public double SolarRadiation { get; set; }
        public double Dew { get; set; }
        public string Precip { get; set; } = string.Empty;
        public double UvIndex { get; set; }
        public double Windspeed { get; set; }
        public string Sunrise { get; set; } = string.Empty;
        public string Sunset { get; set; } = string.Empty;
    }
}
