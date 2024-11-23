using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        private Location[] initialLocation =
        { new Location()
            {
                Id = 1,
                Name = "Mihalkovo",
                Elevation="250",
                FishingType="Trolling,Jigging",
                LocationImageUrl="https://svetogled.com/wp-content/uploads/2021/05/DSC_0680-800x500.jpg"
            },
            new Location()
            {
                Id = 2,
                Name = "Dospat",
                Elevation="1400",
                FishingType="Soft Plastic Lures,Float",
                LocationImageUrl="https://4u-luxury-villa.com/wp-content/uploads/2022/10/Dospat.jpg"
            },
              new Location()
            {
                Id = 3,
                Name = "Gloucester,Massachusetts",
                Elevation="2",
                FishingType="Live bait",
                LocationImageUrl="https://photos.smugmug.com/Aerials/Massachusetts/Gloucester-MA-aerial-photos/i-z7TrSmq/2/LDpDV5CVDMk29PnCDcbvDK6PsqDJVQwXPwCxvTfGF/L/_MG_9999%20-%20Version%202-L.jpg"
            },
                new Location()
            {
                Id = 4,
                Name = "Velilla de Ebro,Spain",
                Elevation="124",
                FishingType="Live bait,Frog lure",
                LocationImageUrl="https://www.iberdrolaespana.com/documents/2692041/3701769/cuenca-ebro-cantabrico-746x419.png/c49350ea-0723-6b45-e37a-49a404380b06?t=1701255674149"
            },
                new Location()
            {
                Id = 5,
                Name = "Kefalonia,Poros",
                Elevation="1",
                FishingType="Lure",
                LocationImageUrl="https://mediaim.expedia.com/destination/1/66f2da633e3df0ef6cefdc10aefc3c1f.jpg"
            },
                    new Location()
            {
                Id = 6,
                Name = "Lefkada",
                Elevation="1",
                FishingType="Lure,Live bait",
                LocationImageUrl="https://theinsidetraveller.com/wp-content/uploads/2024/03/dji_fly_20230723_135658_518_1690174403398_photo-1.jpg?w=1024"
            },
        };

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(initialLocation);
        }
    }
}
