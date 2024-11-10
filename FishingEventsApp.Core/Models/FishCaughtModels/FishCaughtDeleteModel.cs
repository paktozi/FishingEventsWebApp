using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.FishCaughtModels
{
    public class FishCaughtDeleteModel
    {
        public int Id { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string FishName { get; set; } = string.Empty;

        public double Weight { get; set; }

        public double Length { get; set; }
    }
}
