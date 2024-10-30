using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{

    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;


        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();

        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();
    }

}
