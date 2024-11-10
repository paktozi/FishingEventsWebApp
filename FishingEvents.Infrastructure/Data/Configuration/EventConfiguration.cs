using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            },
             new FishingEvent()
             {
                 Id=11,
                EventName="Wicked Tuna",
                Description="Join us for Atlantic bluefin tuna!",
                StartDate=DateTime.ParseExact("07-11-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("19-11-2024", "dd-MM-yyyy", null),
                LocationId=8,
                EventImageUrl="https://play-lh.googleusercontent.com/TphogImhoiplJ6NBslILTd1eko8KCWb-NDirph-RcoMSiga-v-8YfVZWddAvhLwbVSjBJg",
                OrganizerId="8c148075-961f-4ddc-bdb2-416c5bfa1439"
             }
        };


        public void Configure(EntityTypeBuilder<FishingEvent> builder)
        {
            builder.HasData(initialEvent);
        }
    }
}
