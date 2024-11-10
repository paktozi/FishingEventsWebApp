using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Models.WeatherModels
{
    public class Weather
    {

        [JsonProperty("currentConditions")]
        public CurrentConditions Conditions { get; set; }

        public string? ResolvedAddress { get; set; }

        [JsonProperty("alerts")]
        public Alerts[] Alerts { get; set; }


        //public Days[] Days { get; set; }



    }
}
