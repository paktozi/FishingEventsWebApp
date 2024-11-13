using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Models.WeatherModels
{
    public class Days
    {
        public DateTime DateTime { get; set; }

        public string Conditions { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public double TempMin { get; set; }

        public double TempMax { get; set; }
    }
}
