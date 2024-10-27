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
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Required]
        public IdentityUser? User { get; set; }

    }
}
