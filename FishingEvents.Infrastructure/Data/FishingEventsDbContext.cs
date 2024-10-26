using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Infrastructure
{
    public class FishingEventsDbContext : IdentityDbContext<IdentityUser>
    {
        public FishingEventsDbContext(DbContextOptions<FishingEventsDbContext> options)
            : base(options)
        {
        }
    }
}
