using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.FishCaughtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.ApplicationUserModels
{
    public class ApplicationUserAllModel
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
