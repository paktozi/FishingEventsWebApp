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
                Name = "Vucha dam",
                Elevation="250",
                FishingType="Bass,Pike",
                LocationImageUrl="https://svetogled.com/wp-content/uploads/2021/05/DSC_0680-800x500.jpg"
            },
            new Location()
            {
                Id = 2,
                Name = "Dospat dam",
                Elevation="1400",
                FishingType="Bass,Trouth",
                LocationImageUrl="https://4u-luxury-villa.com/wp-content/uploads/2022/10/Dospat.jpg"
            },
        };

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(initialLocation);
        }
    }
}
