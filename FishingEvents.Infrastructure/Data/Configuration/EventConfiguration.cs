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
                LocationId=1,   // Mihalkovo,Vucha dam
                EventImageUrl="https://baileysharbor.com/wp-content/uploads/2023/03/BH-Brown-Trout-23-Logo-1.jpg",
                OrganizerId="e1f8b74c-9b90-4054-ab42-8171c32ed1b2"   //Paul Hebert
            },
             new FishingEvent()
            {
                Id=2,
                EventName="Winter Fishing Festival",
                Description="Join us for a cold day of fishing and fun!",
                StartDate=DateTime.ParseExact("07-11-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("09-11-2024", "dd-MM-yyyy", null),
                LocationId=2,   //Dospat,Dospat dam
                EventImageUrl="https://img.freepik.com/premium-vector/fishing-tournament-logo-template-isolated_384468-27.jpg",
                OrganizerId="2eff85cf-8402-45f8-bb3b-88bbafcc50d2"  //  Admin
            },
             new FishingEvent()
             {
                 Id=3,
                EventName="Wicked Tuna",
                Description="Join us for Atlantic bluefin tuna!",
                StartDate=DateTime.ParseExact("07-11-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("19-11-2024", "dd-MM-yyyy", null),
                LocationId=3,  // Gloucester,Massachusetts
                EventImageUrl="https://play-lh.googleusercontent.com/TphogImhoiplJ6NBslILTd1eko8KCWb-NDirph-RcoMSiga-v-8YfVZWddAvhLwbVSjBJg",
                OrganizerId="8c148075-961f-4ddc-bdb2-416c5bfa1439"  //Dave Marciano
             },
              new FishingEvent()
             {
                 Id=4,
                EventName="Catching Big Barracudas",
                Description="Go to Ionian sea",
                StartDate=DateTime.ParseExact("15-06-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("21-06-2024", "dd-MM-yyyy", null),
                LocationId=6,  // Lefkada
                EventImageUrl="https://static.vecteezy.com/system/resources/thumbnails/023/059/722/small_2x/design-of-barracuda-fishing-vector.jpg",
                OrganizerId="ef082de5-9f29-4f11-adb4-a337f90e3373"  //Tyler McLaughlin
             }
              ,
               new FishingEvent()
             {
                 Id=5,
                EventName="Catching Catfish",
                Description="Big Catfish in Ebro river",
                StartDate=DateTime.ParseExact("07-09-2024", "dd-MM-yyyy", null),
                EndDate=DateTime.ParseExact("19-09-2024", "dd-MM-yyyy", null),
                LocationId=4,  // Velilla de Ebro,Spain
                EventImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLtFBYwC0pUKQmDLimBxIa2V3e8pZ50diWlON8SJtbqMTqvdWu0juQI9vuo-PxMZVySdE&usqp=CAU",
                OrganizerId="f0c1090f-ba41-4420-8446-26f4efb810f1"  //Global Admin
             }
        };


        public void Configure(EntityTypeBuilder<FishingEvent> builder)
        {
            builder.HasData(initialEvent);
        }
    }
}
