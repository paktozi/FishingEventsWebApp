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
                FishImageUrl="https://www.maine.gov/ifw/images/largemouthbass.jpg"
            },
            new Species()
            {
                Id= 2,
                Name="Trout",
                Description="Trout have fins entirely without spines, and all of them have a small adipose fin along the back, near the tail.",
                HabitatName="Trout need cold water to survive.",
                FishBait="lures, live bait, spinner baits, jig bait,camola",
                FishImageUrl="https://media.istockphoto.com/id/1491004547/vector/watercolor-rainbow-trout-hand-drawn-fish-illustration-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=HgyqU9_bg_ytNEIiFclu1oNnnoc44PmUc_vvMF4FEbo="
            }
            ,new Species()
            {
                Id= 3,
                Name="Atlantic bluefin tuna",
                Description="Atlantic bluefin tuna have large, torpedo-shaped bodies that are nearly circular in cross-section.",
                HabitatName="Near offshore islands",
                FishBait="Live bait",
                FishImageUrl="https://images.squarespace-cdn.com/content/v1/5890c07bcd0f685b13dc60bf/1490802646283-GBTVAD6YM4G07UWVZJ12/image-asset.png"
            }
            ,new Species()
            {
                Id= 4,
                Name="Catfish",
                Description="large spindle-shaped body",
                HabitatName="Slow-flowing and swampy bodies of water",
                FishBait="Worms,Minnows and Small Fish",
                FishImageUrl="https://cdn.shopify.com/s/files/1/2527/6546/files/brown_bullhead_480x480.jpg?v=1618523580"
            }
            ,new Species()
            {
                Id= 5,
                Name="Barracuda",
                Description="The fish has a long, slender body that is tapered at the ends and thicker in the middle.",
                HabitatName="Seagrass beds, mangroves, and coral reefs.",
                FishBait="Live bait,Lure",
                FishImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf4kpsp3YY-spyzPn86Mhq0MXFyMzHhdtYQmrDdXVcL5nNdQbVi2yt-ZBpdmqZtPXHmA&usqp=CAU"
            }
             ,new Species()
            {
                Id= 6,
                Name="Perch",
                Description="Perch have a long and round body shape which allows for fast swimming in the water.",
                HabitatName="Freshwater ponds, lakes, streams, or rivers.",
                FishBait="Jig,Lure,Worms",
                FishImageUrl="https://portal.ct.gov/-/media/deep/fishing/freshwater/freshwater_fishes/perches-and-darters/74ayellowperchacompressed.jpg?rev=9152b888941e4650bc94dd51c0b713e3&sc_lang=en&hash=F3D205D82079E5FAA26D6BB0FE116D86q=tbn:ANd9GcSsxP5wYue8ZxzOp8mTJTMUe5pN6O0AC_NPhw&s"
            }
              ,new Species()
            {
                Id= 7,
                Name="Carp",
                Description="The common carp is a heavy-bodied minnow with barbels on either side of the upper jaw.",
                HabitatName="Still or slowly flowing waters at low altitudes.",
                FishBait="Sweetcorn,Boilies,Pellets",
                FishImageUrl="https://badangling.com/wp-content/uploads/2018/06/common-carp-species.jpg"
            }
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(initialSpecies);
        }
    }
}
