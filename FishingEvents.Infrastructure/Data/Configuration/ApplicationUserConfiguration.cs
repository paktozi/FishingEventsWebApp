using FishingEvents.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                UserName = "admin@abv.bg",
                NormalizedUserName = "ADMIN@ABV.BG",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Admin",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "qazwsx")
            };

            var user1 = new ApplicationUser
            {
                Id = "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                UserName = "user1@abv.bg",
                NormalizedUserName = "USER1@ABV.BG",
                Email = "user1@abv.bg",
                NormalizedEmail = "USER1@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Dave",
                LastName = "Marciano",
                PasswordHash = hasher.HashPassword(null, "qazwsx")
            };


            var user2 = new ApplicationUser
            {
                Id = "ef082de5-9f29-4f11-adb4-a337f90e3373",
                UserName = "user2@abv.bg",
                NormalizedUserName = "USER2@ABV.BG",
                Email = "user2@abv.bg",
                NormalizedEmail = "USER2@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Tyler",
                LastName = "McLaughlin",
                PasswordHash = hasher.HashPassword(null, "qazwsx")
            };


            var user3 = new ApplicationUser
            {
                Id = "5667e464-5a99-44f1-81cd-6e9022965a07",
                UserName = "user3@abv.bg",
                NormalizedUserName = "USER3@ABV.BG",
                Email = "user3@abv.bg",
                NormalizedEmail = "USER3@ABV.BG",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                FirstName = "TJ",
                LastName = "Ott",
                PasswordHash = hasher.HashPassword(null, "qazwsx")
            };

            builder.HasData(adminUser, user1, user2, user3);
        }
    }
}
