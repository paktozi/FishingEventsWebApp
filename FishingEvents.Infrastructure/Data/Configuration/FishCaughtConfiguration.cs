using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class FishCaughtConfiguration : IEntityTypeConfiguration<FishCaught>
    {
        private FishCaught[] initialFishCaught =
        {
             new FishCaught()
            {
               Id=1,
               FishingEventId=3, //Wicked Tuna
               UserId="8c148075-961f-4ddc-bdb2-416c5bfa1439",//Dave Marciano
               SpeciesId=3, //Atlantic bluefin tuna
               Weight=544,
               Length=230,
               CaughtImageUrl="https://www.looper.com/img/gallery/facts-about-wicked-tunas-dave-marciano-you-wont-have-to-fish-for/a-1200-pound-bluefin-tuna-was-his-largest-catch-1666893399.jpg",
               DateCaught=DateTime.ParseExact("10-11-2024", "dd-MM-yyyy", null),
            },
             new FishCaught()
            {
               Id=2,
               FishingEventId=3, //Wicked Tuna
               UserId="a7dded57-50b8-4c59-8148-619b8d2a1266",//Dave Carraro
               SpeciesId=3, //Atlantic bluefin tuna
               Weight=207,
               Length=195,
               CaughtImageUrl="https://www.pressherald.com/wp-content/uploads/sites/4/2013/04/portland-press-herald_3753041.jpg?w=800",
               DateCaught=DateTime.ParseExact("12-11-2024", "dd-MM-yyyy", null),
            },
              new FishCaught()
            {
               Id=3,
               FishingEventId=3,//Wicked Tuna
               UserId="ef082de5-9f29-4f11-adb4-a337f90e3373", //Tyler McLaughlin
               SpeciesId=3, //Atlantic bluefin tuna
               Weight=207,
               Length=212,
               CaughtImageUrl="https://media.distractify.com/brand-img/6Eeo0qnci/0x0/tyler-marissa-wicked-tuna-1559414259195.jpg",
               DateCaught=DateTime.ParseExact("14-11-2024", "dd-MM-yyyy", null),
            },
               new FishCaught()
            {
               Id=4,
               FishingEventId=3, //Wicked Tuna
               UserId="8c148075-961f-4ddc-bdb2-416c5bfa1439",//Dave Marciano
               SpeciesId=3, //Atlantic bluefin tuna
               Weight=230,
               Length=208,
               CaughtImageUrl="https://a57.foxnews.com/static.foxnews.com/foxnews.com/content/uploads/2020/03/1200/675/TheFleetStrikesBack_WickedTuna_Ep707_LR_18.jpg?ve=1&tl=1",
               DateCaught=DateTime.ParseExact("16-11-2024", "dd-MM-yyyy", null),
            },
               new FishCaught()
            {
               Id=5,
               FishingEventId=4, //Catching Big Barracudas
               UserId="5667e464-5a99-44f1-81cd-6e9022965a07",//TJ Ott
               SpeciesId=5, //Barracuda
               Weight=41,
               Length=172,
               CaughtImageUrl="https://www.howtocatchanyfish.com/uploads/8/8/0/2/8802125/cuda2_orig.jpg",
               DateCaught=DateTime.ParseExact("16-06-2024", "dd-MM-yyyy", null),
            },
               new FishCaught()
            {
               Id=6,
               FishingEventId=4, //Catching Big Barracudas
               UserId="e1f8b74c-9b90-4054-ab42-8171c32ed1b2",  //Paul Hebert
               SpeciesId=5, //Barracuda
               Weight=52,
               Length=191,
               CaughtImageUrl="https://alphonsefishingco.com/wp-content/uploads/2023/06/seychelles-alphonse-island-species-barracuda-06.jpg",
               DateCaught=DateTime.ParseExact("16-06-2024", "dd-MM-yyyy", null),
            }
        };


        public void Configure(EntityTypeBuilder<FishCaught> builder)
        {
            builder.HasData(initialFishCaught);
        }
    }
}
