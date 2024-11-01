using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventALLModel
    {
        public int Id { get; set; }


        public string EventName { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;


        public string StartDate { get; set; } = string.Empty;



        public string EndDate { get; set; } = string.Empty;



        public string LocationName { get; set; } = string.Empty;


        public string Organizer { get; set; } = string.Empty;

        public string EventImageUrl { get; set; } = string.Empty;

        public bool IsOrganizer { get; set; }

        public bool IsJoined { get; set; }

        public string Mail { get; set; } = string.Empty;
    }
}
