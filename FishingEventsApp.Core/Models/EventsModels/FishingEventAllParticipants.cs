using FishingEventsApp.Core.Models.FishCaughtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventAllParticipants
    {
        public string UserId { get; set; } = null!;

        public int EventId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;



        public ICollection<FishCaughtAllModel> FishCaughtsList { get; set; } = new List<FishCaughtAllModel>();
        //public ICollection<FishingEventALLModel> FishingEventsList { get; set; } = new List<FishingEventALLModel>();

    }
}
