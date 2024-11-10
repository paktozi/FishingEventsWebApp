using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Models.WeatherModels
{
    public class Alerts
    {
        public string Event { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
