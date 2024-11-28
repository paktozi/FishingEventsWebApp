using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Tests
{
    [TestFixture]
    public class FishingEventServiceTests
    {
        private IFishingEventService fishingEventService;
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
            context.Locations.Add(new Location
            {
                Id = 1,
                Name = "Lake Tahoe",
                Elevation = "6225",
                FishingType = "Freshwater",
                LocationImageUrl = "imageUrl"
            });

            context.Users.AddRange(new[]
            {
                new ApplicationUser
                {
                    Id = "user1",
                    FirstName = "John",
                    LastName = "Doe"
                },
                new ApplicationUser
                {
                    Id = "user2",
                    FirstName = "Jane",
                    LastName = "Smith"
                }
            });

            context.FishingEvents.AddRange(new[]
            {
                new FishingEvent
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
                },
                new FishingEvent
                {
                    Id = 2,
                    EventName = "Fishing Event 2",
                    Description = "Test Event 2",
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now.AddDays(-2),
                    LocationId = 1,
                    OrganizerId = "user2",
                    IsCompleted = true,
                    EventImageUrl = "eventImageUrl2"
                }
            });

            context.SaveChanges();

            // Create service instance
            fishingEventService = new FishingEventService(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetAllEventsAsync_ShouldReturnActiveEvents()
        {
            // Act
            var result = await fishingEventService.GetAllEventsAsync(null, null, null);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().EventName, Is.EqualTo("Fishing Event 1"));
        }

        [Test]
        public async Task AddFishingEventAsync_ShouldAddNewEvent()
        {
            // Arrange
            var dateFormat = "dd-MM-yyyy";
            var newEvent = new FishingEventAddModel
            {
                EventName = "New Fishing Event",
                Description = "Exciting fishing event",
                StartDate = DateTime.Now.AddDays(2).ToString(dateFormat),
                EndDate = DateTime.Now.AddDays(3).ToString(dateFormat),
                LocationId = 1,
                EventImageUrl = "newImageUrl"
            };

            // Act
            await fishingEventService.AddFishingEventAsync(newEvent, "user2");

            // Assert
            var addedEvent = context.FishingEvents.FirstOrDefault(e => e.EventName == "New Fishing Event");
            Assert.That(addedEvent, Is.Not.Null);
            Assert.That(addedEvent.Description, Is.EqualTo("Exciting fishing event"));
            Assert.That(addedEvent.OrganizerId, Is.EqualTo("user2"));
        }

        [Test]
        public async Task JoinEventAsync_ShouldAddParticipantToEvent()
        {
            // Act
            await fishingEventService.JoinEventAsync(1, "user2");

            // Assert
            var participant = context.EventParticipants.FirstOrDefault(ep => ep.FishingEventId == 1 && ep.UserId == "user2");
            Assert.That(participant, Is.Not.Null);
        }

        [Test]
        public async Task LeaveAsync_ShouldRemoveParticipantFromEvent()
        {
            // Arrange
            context.EventParticipants.Add(new EventParticipant
            {
                FishingEventId = 1,
                UserId = "user2"
            });
            context.SaveChanges();

            var eventToLeave = await context.FishingEvents.FirstOrDefaultAsync(e => e.Id == 1);

            // Act
            await fishingEventService.LeaveAsync(eventToLeave, "user2");

            // Assert
            var participant = context.EventParticipants.FirstOrDefault(ep => ep.FishingEventId == 1 && ep.UserId == "user2");
            Assert.That(participant, Is.Null);
        }

        [Test]
        public async Task DeleteEventAsync_ShouldMarkEventAsCompleted()
        {
            // Arrange
            var eventToDelete = await context.FishingEvents.FirstOrDefaultAsync(e => e.Id == 1);

            // Act
            await fishingEventService.DeleteEventAsync(eventToDelete);

            // Assert
            Assert.That(eventToDelete.IsCompleted, Is.True);
            var remainingParticipants = context.EventParticipants.Where(ep => ep.FishingEventId == 1);
            Assert.That(remainingParticipants, Is.Empty);
        }


    }
}
