using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.LocationModels;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Tests
{
    public class LocationServiceTests
    {
        private ILocationService locationService;
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
            context.SaveChanges();

            // Create service instance
            locationService = new LocationService(context, null);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddLocationAsync_ShouldAddNewLocation()
        {
            // Arrange
            var newLocation = new LocationAddModel
            {
                Name = "Lake Michigan",
                Elevation = "594",
                FishingType = "Freshwater",
                LocationImageUrl = "lakeMichiganImageUrl"
            };

            // Act
            await locationService.AddLocationAsync(newLocation);

            // Assert
            var addedLocation = context.Locations.FirstOrDefault(l => l.Name == "Lake Michigan");
            Assert.That(addedLocation, Is.Not.Null);
            Assert.That(addedLocation.Name, Is.EqualTo("Lake Michigan"));
            Assert.That(addedLocation.Elevation, Is.EqualTo("594"));
            Assert.That(addedLocation.FishingType, Is.EqualTo("Freshwater"));
        }

        [Test]
        public async Task DeleteLocationAsync_ShouldRemoveLocation()
        {
            // Arrange
            var locationToDelete = await context.Locations.FirstOrDefaultAsync(l => l.Id == 1);

            // Act
            await locationService.DeleteLocationAsync(locationToDelete);

            // Assert
            var deletedLocation = await context.Locations.FirstOrDefaultAsync(l => l.Id == 1);
            Assert.That(deletedLocation, Is.Null);
        }

        [Test]
        public async Task EditLocationAsync_ShouldUpdateLocation()
        {
            // Arrange
            var locationToEdit = await context.Locations.FirstOrDefaultAsync(l => l.Id == 1);
            var editModel = new LocationEditModel
            {
                Name = "Lake Tahoe Updated",
                Elevation = "6500",
                FishingType = "Saltwater",
                LocationImageUrl = "updatedImageUrl"
            };

            // Act
            await locationService.EditLocationAsync(editModel, locationToEdit);

            // Assert
            var editedLocation = await context.Locations.FirstOrDefaultAsync(l => l.Id == 1);
            Assert.That(editedLocation, Is.Not.Null);
            Assert.That(editedLocation.Name, Is.EqualTo("Lake Tahoe Updated"));
            Assert.That(editedLocation.Elevation, Is.EqualTo("6500"));
            Assert.That(editedLocation.FishingType, Is.EqualTo("Saltwater"));
        }

        [Test]
        public async Task FindLocationAsync_ShouldReturnCorrectLocation()
        {
            // Act
            var location = await locationService.FindLocationAsync(1);

            // Assert
            Assert.That(location, Is.Not.Null);
            Assert.That(location.Name, Is.EqualTo("Lake Tahoe"));
            Assert.That(location.Elevation, Is.EqualTo("6225"));
        }

        [Test]
        public async Task GetAllLocationsAsync_ShouldReturnAllLocations()
        {
            // Act
            var locations = await locationService.GetAllLocationsAsync(null);

            // Assert
            Assert.That(locations, Is.Not.Null);
            Assert.That(locations.Count(), Is.EqualTo(1));
            Assert.That(locations.First().Name, Is.EqualTo("Lake Tahoe"));
        }

        [Test]
        public async Task GetAllLocationsAsync_WithFilter_ShouldReturnFilteredLocations()
        {
            // Act
            var locations = await locationService.GetAllLocationsAsync("Lake");

            // Assert
            Assert.That(locations, Is.Not.Null);
            Assert.That(locations.Count(), Is.EqualTo(1));
            Assert.That(locations.First().Name, Is.EqualTo("Lake Tahoe"));
        }

    }
}
