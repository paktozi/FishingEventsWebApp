using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.FishCaughtModels
{
    public class FishCaughtAllModel
    {
        public int Id { get; set; }

        // public int FishingEventId { get; set; }

        public string FishingEventName { get; set; }

        //public string UserId { get; set; } = string.Empty;

        public string Species { get; set; }

        public double Weight { get; set; }

        public double Length { get; set; }

        public string? CaughtImageUrl { get; set; }

        public string DateCaught { get; set; } = string.Empty;
    }
}
