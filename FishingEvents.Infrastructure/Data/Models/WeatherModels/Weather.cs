﻿using Newtonsoft.Json;

namespace FishingEvents.Infrastructure.Data.Models.WeatherModels
{
    public class Weather
    {
        [JsonProperty("currentConditions")]
        public CurrentConditions Conditions { get; set; } = null!;

        public string? ResolvedAddress { get; set; }

        [JsonProperty("alerts")]
        public Alerts[] Alerts { get; set; } = null!;

        public Days[] Days { get; set; } = null!;
    }
}
