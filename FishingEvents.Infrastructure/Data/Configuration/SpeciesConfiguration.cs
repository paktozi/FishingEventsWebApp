using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            ,new Species()
            {
                Id= 9,
                Name="Atlantic bluefin tuna",
                Description="Atlantic bluefin tuna have large, torpedo-shaped bodies that are nearly circular in cross-section.",
                HabitatName="Near offshore islands",
                FishBait="Live bait",
                FishImageUrl="https://images.squarespace-cdn.com/content/v1/5890c07bcd0f685b13dc60bf/1490802646283-GBTVAD6YM4G07UWVZJ12/image-asset.png"
            }
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(initialSpecies);
        }
    }
}
