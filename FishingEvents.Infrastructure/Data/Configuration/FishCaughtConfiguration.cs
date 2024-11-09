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
    public class FishCaughtConfiguration : IEntityTypeConfiguration<FishCaught>
    {
        private FishCaught[] initialFishCaught =
        {
            new FishCaught()
            {
               Id=1,
               FishingEventId=1,
               UserId="f22d4414-0146-4947-8aa8-4b5179bc0160",
               SpeciesId=1,
               Weight=0.250,
               Length=0.50,
               CaughtImageUrl="https://targetwalleye.com/wp-content/uploads/2019/11/Jake-Caughey-winnipeg-manitoba-target-walleye-greenback_edited-1.jpg",
               DateCaught=DateTime.ParseExact("01-05-2024", "dd-MM-yyyy", null),
            },
             new FishCaught()
            {
               Id=2,
               FishingEventId=1,
               UserId="f22d4414-0146-4947-8aa8-4b5179bc0160",
               SpeciesId=2,
               Weight=1.450,
               Length=0.90,
               CaughtImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJp8v1JFGqRH1BLyOwv-48FlCGg4kwxyN-VFvtYnxvUbzVAh_VaTjBjf7xGipUG4K_c4&usqp=CAU",
               DateCaught=DateTime.ParseExact("01-05-2024", "dd-MM-yyyy", null),
            },
              new FishCaught()
            {
               Id=19,
               FishingEventId=11,
               UserId="ef082de5-9f29-4f11-adb4-a337f90e3373",
               SpeciesId=9,
               Weight=350,
               Length=2.25,
               CaughtImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_TKag7a673r_RBIcKFqIe-_6BjB6Oob4nqw&s",
               DateCaught=DateTime.ParseExact("01-05-2024", "dd-MM-yyyy", null),
            },
        };


        public void Configure(EntityTypeBuilder<FishCaught> builder)
        {
            builder.HasData(initialFishCaught);
        }
    }
}
