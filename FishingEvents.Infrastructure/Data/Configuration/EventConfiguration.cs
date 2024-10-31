using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<FishingEvent>
    {
        private FishingEvent[] initialEvent =
        {
            new FishingEvent()
            {
                Id=1,
                EventName="Spring Fishing Festival",
                Description="Join us for a day of fishing and fun!",
                StartDate=DateTime.ParseExact("01-05-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("02-05-2024", "dd-MM-yyyy", null),
                LocationId=1,
                EventImageUrl="https://baileysharbor.com/wp-content/uploads/2023/03/BH-Brown-Trout-23-Logo-1.jpg",
                OrganizerId="f22d4414-0146-4947-8aa8-4b5179bc0160"
            },
             new FishingEvent()
            {
                Id=2,
                EventName="Winter Fishing Festival",
                Description="Join us for a cold day of fishing and fun!",
                StartDate=DateTime.ParseExact("07-11-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("09-11-2024", "dd-MM-yyyy", null),
                LocationId=2,
                EventImageUrl="https://img.freepik.com/premium-vector/fishing-tournament-logo-template-isolated_384468-27.jpg",
                OrganizerId="f22d4414-0146-4947-8aa8-4b5179bc0160"
            }
        };


        public void Configure(EntityTypeBuilder<FishingEvent> builder)
        {
            builder.HasData(initialEvent);
        }
    }
}
