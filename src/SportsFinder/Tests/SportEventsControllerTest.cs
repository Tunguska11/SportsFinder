using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using SportsFinder.Data;
using SportsFinder.Models;
using Xunit;
using Xunit.Abstractions;
using SportsFinder.Controllers;

namespace SportsFinder.Tests
{
    public class SportEventsControllerTest
    {
        private TestDbContext _context;
        private SportEventsTestController _controller;
        private readonly ITestOutputHelper output;

        public SportEventsControllerTest(ITestOutputHelper output)
        {
            this.output = output;

            // Init DbContext in memory
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();
            _context = new TestDbContext(optionsBuilder.Options);

            // Seed some data
            _context.SportEvent.Add(new SportEvent()
            {
                ID= 1,
                EventTime = DateTime.Now,
                EventSport = "Rock Climbing",
                IsTentative = false,
                Longitude = 30,
                Latitude = -80,
                PplAttendingCount = 3,
                MaxPeopleAllowed = 6,
                EquipmentList = "chalk bag, harness, climbing shoes"
            });
            _context.SportEvent.Add(new SportEvent()
            {
                ID = 2,
                EventTime = DateTime.Now,
                EventSport = "Soccer",
                IsTentative = false,
                Longitude = 30.5,
                Latitude = -80.5,
                PplAttendingCount = 7,
                MaxPeopleAllowed = 22,
                EquipmentList = "soccer ball"
            });
            _context.SaveChanges();

            // Create test controller
            _controller = new SportEventsTestController(_context);
        }

        [Fact]
        public void GetSportEventRockClimbing_ReturnsRockClimbing()
        {
            // Act
            var result = _controller.Details(1) as ViewResult;

            // Assert
            Assert.IsType(typeof(SportEvent), result.ViewData.Model);
            SportEvent sportEvent = (SportEvent)result.ViewData.Model;
            Assert.Equal("Rock Climbing", sportEvent.EventSport);
        }

        [Fact]
        public void GetNonSportEvent_ReturnsNull()
        {
            // Act
            var result = _controller.Details(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddEventSavesToDbWithCorrectId()
        {
            // Arrange
            int sportEventId = 100;
            SportEvent sportEvent = new SportEvent()
            {
                ID = sportEventId,
                EventTime = DateTime.Now,
                EventSport = "Cricket",
                IsTentative = false,
                Longitude = 30.45,
                Latitude = -80.24,
                PplAttendingCount = 3,
                MaxPeopleAllowed = 15,
                EquipmentList = "none"
            };
            var beforeEventCount = _context.SportEvent.Count();

            // Act
            var result = _controller.Create(sportEvent);

            // Assert
            SportEvent savedSportEvent = _context.SportEvent.Single(x => x.EventSport == "Cricket" && x.PplAttendingCount == 3);
            Assert.Equal(sportEventId, savedSportEvent.ID);
            Assert.Equal(beforeEventCount + 1, _context.SportEvent.Count());
        }

        [Fact]
        public void UpdateSportEvent_ReflectsUpdate()
        {
            // Add sportevent to db
            SportEvent sportEvent = new SportEvent()
            {
                ID=3,
                EventTime = DateTime.Now,
                EventSport = "Mountain Biking",
                IsTentative = false,
                Longitude = 30.123,
                Latitude = -80.432,
                PplAttendingCount = 2,
                MaxPeopleAllowed = 10,
                EquipmentList = "mountain bike, helmet"
            };
            _controller.Create(sportEvent);

            // Get added sport event to edit it
            var result = _controller.Edit(3) as ViewResult;
            SportEvent retrievedEvent = (SportEvent)result.ViewData.Model;

            // Check PplAttendingCount is 2
            Assert.Equal(2, retrievedEvent.PplAttendingCount);

            // Change PplAttendingCount to 4
            retrievedEvent.PplAttendingCount = 4;
            _controller.Edit(retrievedEvent);

            // Lookback up to verify change
            var result2 = _controller.Details(3) as ViewResult;
            var changedEvent = (SportEvent)result2.ViewData.Model;
            Assert.Equal(4, changedEvent.PplAttendingCount);
        }
    }
}