using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
        public ICollection<FishCaught> FishCaught { get; set; } = new List<FishCaught>();
        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }
}
