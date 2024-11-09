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
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        private Location[] initialLocation =
        {
            new Location()
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
                Id = 8,
                Name = "Gloucester,Massachusetts",
                Elevation="2",
                FishingType="Live bait",
                LocationImageUrl="https://photos.smugmug.com/Aerials/Massachusetts/Gloucester-MA-aerial-photos/i-z7TrSmq/2/LDpDV5CVDMk29PnCDcbvDK6PsqDJVQwXPwCxvTfGF/L/_MG_9999%20-%20Version%202-L.jpg"
            },
        };

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(initialLocation);
        }
    }
}
