using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishingEvents.Infrastructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                new IdentityUserRole<string>
                {
                    UserId = "2eff85cf-8402-45f8-bb3b-88bbafcc50d2", // Admin user ID
                    RoleId = "a5f38997-71be-4d64-b6b8-0e741de5d2b5" // Admin role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "8c148075-961f-4ddc-bdb2-416c5bfa1439", // User1 ID
                    RoleId = "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128" // User role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "ef082de5-9f29-4f11-adb4-a337f90e3373", // User2 ID
                    RoleId = "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128" // User role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "5667e464-5a99-44f1-81cd-6e9022965a07", // User3 ID
                    RoleId = "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128" // User role ID
                },
                 new IdentityUserRole<string>
                 {
                     UserId = "f0c1090f-ba41-4420-8446-26f4efb810f1", // GlobalAdmin user ID
                     RoleId = "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1" // GlobalAdmin role ID
                 }
            );
        }
    }
}
