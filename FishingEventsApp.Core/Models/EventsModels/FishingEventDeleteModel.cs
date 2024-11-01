using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventDeleteModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Organizer { get; set; } = string.Empty;
    }
}
