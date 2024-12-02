using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Services;
using FishingEventsApp.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Tests
{
    [TestFixture]
    public class UserRoleServiceTests
    {
        private FishingEventsDbContext dbContext;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole>> roleManagerMock;
        private IUserRoleService userRoleService;

        [SetUp]
        public void Setup()
        {
            // Create in-memory database options
            var options = new DbContextOptionsBuilder<FishingEventsDbContext>()
                .UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}") // Unique database name for each test run
                .Options;

            dbContext = new FishingEventsDbContext(options);

            // Initialize mock UserManager and RoleManager
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object, null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object, null, null, null, null);

            // Seed initial data
            dbContext.Users.AddRange(new[]
            {
                new ApplicationUser { Id = "user1", UserName = "JohnDoe" },
                new ApplicationUser { Id = "user2", UserName = "JaneSmith" }
            });

            dbContext.Roles.AddRange(new[]
            {
                new IdentityRole { Id = "role1", Name = "User" },
                new IdentityRole { Id = "role2", Name = "Admin" }
            });

            dbContext.UserRoles.AddRange(new[]
            {
                new IdentityUserRole<string> { UserId = "user1", RoleId = "role1" },
                new IdentityUserRole<string> { UserId = "user2", RoleId = "role2" }
            });

            dbContext.SaveChanges();

            // Initialize UserRoleService
            userRoleService = new UserRoleService(userManagerMock.Object, roleManagerMock.Object, dbContext);
        }

        [Test]
        public async Task GetUsersWithRolesAsync_ShouldReturnUsersWithoutGlobalAdminRole()
        {
            // Arrange
            var globalAdminRole = "GlobalAdmin";
            dbContext.Roles.Add(new IdentityRole { Id = "role3", Name = globalAdminRole });
            dbContext.UserRoles.Add(new IdentityUserRole<string> { UserId = "user1", RoleId = "role3" });
            dbContext.SaveChanges();

            // Act
            var result = await userRoleService.GetUsersWithRolesAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().UserName, Is.EqualTo("JaneSmith"));
        }

        [Test]
        public async Task AddRoleToUserAsync_ShouldAddRoleToUser()
        {
            // Arrange
            var userId = "user1";
            var roleName = "Admin";
            userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(new ApplicationUser { Id = userId });
            roleManagerMock.Setup(rm => rm.RoleExistsAsync(roleName)).ReturnsAsync(true);
            userManagerMock.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), roleName)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await userRoleService.AddRoleToUserAsync(userId, roleName);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task RemoveRoleFromUserAsync_ShouldRemoveRoleFromUser()
        {
            // Arrange
            var userId = "user2";
            var roleName = "Admin";
            userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(new ApplicationUser { Id = userId });
            userManagerMock.Setup(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), roleName)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await userRoleService.RemoveRoleFromUserAsync(userId, roleName);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task FindUserAsync_ShouldReturnUser()
        {
            // Arrange
            var userId = "user1";

            // Act
            var result = await userRoleService.FindUserAsync(userId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo("JohnDoe"));
        }


        [TearDown]
        public async Task TearDown()
        {
            // Dispose of dbContext after each test
            if (dbContext != null)
            {
                await dbContext.DisposeAsync();
            }
        }

    }
}
