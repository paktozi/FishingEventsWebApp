using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        private EventParticipant[] initialParticipant =
        {
            new EventParticipant()
            {
                FishingEventId=3,  //Wicked Tuna
                UserId="8c148075-961f-4ddc-bdb2-416c5bfa1439" //Dave Marciano
            },
             new EventParticipant()
            {
                FishingEventId=3,  //Wicked Tuna
                UserId="ef082de5-9f29-4f11-adb4-a337f90e3373" //Tyler McLaughlin
            },
              new EventParticipant()
            {
                FishingEventId=3,  //Wicked Tuna
                UserId="a7dded57-50b8-4c59-8148-619b8d2a1266" //Dave Carraro
            },
                new EventParticipant()
            {
                FishingEventId=4,  //Catching Big Barracudas
                UserId="e1f8b74c-9b90-4054-ab42-8171c32ed1b2" //Paul Hebert
            },
                new EventParticipant()
            {
                FishingEventId=4,  //Catching Big Barracudas
                UserId="5667e464-5a99-44f1-81cd-6e9022965a07" //TJ Ott
            },
        };


        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasData(initialParticipant);
        }
    }
}
