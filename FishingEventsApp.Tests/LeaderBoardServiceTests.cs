using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Tests
{
    public class LeaderBoardServiceTests
    {
        private ILeaderBoardService leaderBoardService;
        private FishingEventsDbContext context;

        [SetUp]
        public void Setup()
        {
            // Configure in-memory database
            var options = new DbContextOptionsBuilder<FishingEventsDbContext>()
                .UseInMemoryDatabase("FishingEventsTestDb")
                .Options;
            context = new FishingEventsDbContext(options);

            // Seed initial data
            context.Users.AddRange(new[]
            {
        new ApplicationUser { Id = "user1", FirstName = "John", LastName = "Doe" },
        new ApplicationUser { Id = "user2", FirstName = "Jane", LastName = "Smith" }
    });

            context.FishCaughts.AddRange(new[]
            {
        new FishCaught { UserId = "user1", FishingEventId = 1, Weight = 2.5 },
        new FishCaught { UserId = "user1", FishingEventId = 1, Weight = 3.0 },
        new FishCaught { UserId = "user2", FishingEventId = 1, Weight = 1.5 }
    });

            context.EventParticipants.AddRange(new[]
            {
        new EventParticipant { FishingEventId = 1, UserId = "user1" },
        new EventParticipant { FishingEventId = 1, UserId = "user2" }
    });

            context.FishingEvents.Add(new FishingEvent
            {
                Id = 1,
                EventName = "Fishing Event 1",
                Description = "Test Event",
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(1),
                LocationId = 1,
                OrganizerId = "user1",
                IsCompleted = false,
                EventImageUrl = "eventImageUrl"
            });

            context.SaveChanges();

            // Create service instance
            leaderBoardService = new LeaderBoardService(context);
        }


        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetGeneralLeaderboardAsync_ShouldReturnCorrectLeaderboard()
        {
            // Act
            var result = await leaderBoardService.GetGeneralLeaderboardAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("John"));
            Assert.That(result.First().TotalWeight, Is.EqualTo(5.5));
        }

        [Test]
        public async Task GetLeaderboardAsync_ShouldReturnCorrectLeaderboardForEvent()
        {
            // Act
            var result = await leaderBoardService.GetLeaderboardAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().FirstName, Is.EqualTo("John"));
            Assert.That(result.First().TotalWeight, Is.EqualTo(5.5));
        }
    }
}

