using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Infrastructure
{
    public class FishingEventsDbContext : IdentityDbContext
    {
        public FishingEventsDbContext(DbContextOptions<FishingEventsDbContext> options)
            : base(options)
        {
        }
    }
}
