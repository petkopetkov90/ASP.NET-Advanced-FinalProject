using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services;
using FleetRouteManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FleetRouteManager.Tests.ServicesTests
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IVehicleService vehicleService;
        private Mock<IRepository<Vehicle, int>> mockRepository;
        private FleetRouteManagerDbContext context;


        [SetUp]
        public async Task SetUp()
        {
            mockRepository = new Mock<IRepository<Vehicle, int>>();
            vehicleService = new VehicleService(mockRepository.Object);

            var options = new DbContextOptionsBuilder<FleetRouteManagerDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            this.context = new FleetRouteManagerDbContext(options);

            mockRepository.Setup(repo => repo.GetAllAsIQueryable()).Returns(context.Vehicles);

            await SeedInMemoryDatabase();
        }

        [TearDown]
        public void Dispose()
        {
            context.Dispose();
        }

        [Test]
        public async Task GetAllVehiclesAsyncShouldReturnProperCollectionWithoutSoftDeletedEntities()
        {
            var result = await vehicleService.GetAllVehiclesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(context.Vehicles.Count(v => v.IsDeleted == false)));
            Assert.That(result.Count(), Is.Not.EqualTo(context.Vehicles.Count()));

            foreach (var vehicle in context.Vehicles)
            {
                vehicle.IsDeleted = true;
            }

            await context.SaveChangesAsync();

            result = await vehicleService.GetAllVehiclesAsync();

            Assert.That(result.Count(), Is.EqualTo(0));
            Assert.That(result, Is.Empty);
        }

        private async Task SeedInMemoryDatabase()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    RegistrationNumber = "CB 1111 CB",
                    Vin = "1111111111",
                    Manufacturer = new Manufacturer{Id = 1, Name = "First"},
                    Model = "First Model",
                    FirstRegistration = new DateTime(2001, 01,01),
                    EuroClass = EuroClass.Euro1,
                    VehicleType= new VehicleType{Id = 1, Type = "First"}
                },
                new Vehicle
                {
                    Id = 2,
                    RegistrationNumber = "CB 2222 CB",
                    Vin = "2222222222",
                    Manufacturer = new Manufacturer{Id = 2, Name = "Second"},
                    Model = "Second Model",
                    FirstRegistration = new DateTime(2002, 02,02),
                    EuroClass = EuroClass.Euro2,
                    VehicleType= new VehicleType{Id = 2, Type = "Second"}
                },
                new Vehicle
                {
                    Id = 3,
                    RegistrationNumber = "CB 3333 CB",
                    Vin = "3333333333",
                    Manufacturer = new Manufacturer{Id = 3, Name = "Third"},
                    Model = "Third Model",
                    FirstRegistration = new DateTime(2003, 03,03),
                    EuroClass = EuroClass.Euro3,
                    VehicleType= new VehicleType{Id = 3, Type = "Third"},
                    IsDeleted = true
                }
            };

            context.Vehicles.AddRange(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
