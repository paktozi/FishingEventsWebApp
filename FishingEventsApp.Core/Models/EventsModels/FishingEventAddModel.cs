using FishingEvents.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventAddModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(FishingEventNameMaxLength, MinimumLength = FishingEventNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string EventName { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(FishingEventDescriptionMaxLength, MinimumLength = FishingEventDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$", ErrorMessage = DateErrorMessage)]
        public string StartDate { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$", ErrorMessage = DateErrorMessage)]
        public string EndDate { get; set; } = string.Empty;


        [Required]
        public int LocationId { get; set; }

        public string? EventImageUrl { get; set; } = string.Empty;

        public IEnumerable<FishingLocationModel>? Locations { get; set; } = new List<FishingLocationModel>();
    }
}
