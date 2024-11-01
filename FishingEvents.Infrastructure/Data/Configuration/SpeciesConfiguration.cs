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
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        private Species[] initialSpecies =
        {
            new Species()
            {
                 Id = 1,
                Name="Bass",
                Description="They are generally silvery white in color and most have dark horizontal lines along their sides.",
                HabitatName="Lakes or shallow bays of larger lakes.",
                FishBait="lures, live bait, spinner baits, jig bait",
                FishImageUrl="https://www.graytaxidermy.com/images/large-fishmount-photos/large-mouth-bass-silo.jpg"
            },
            new Species()
            {
                Id= 2,
                Name="Trout",
                Description="Trout have fins entirely without spines, and all of them have a small adipose fin along the back, near the tail.",
                HabitatName="Trout need cold water to survive.",
                FishBait="lures, live bait, spinner baits, jig bait,camola",
                FishImageUrl="https://images.squarespace-cdn.com/content/v1/5be9e00d5b409b36bd17e36f/a9b6dce2-17eb-4c9c-9755-78cff2f43c87/Dorado+%28Mahi+Mahi%29+Coryphaena+Hippurus.jpeg"
            }
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(initialSpecies);
        }
    }
}
