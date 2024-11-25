using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

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

            await SeedInMemoryDatabase();

            MockConfig();
        }

        [TearDown]
        public void Dispose()
        {
            context.Dispose();
        }

        [Test]
        public async Task GetAllVehiclesAsyncShouldReturnCollectionWithoutSoftDeletedEntities()
        {
            var result = await vehicleService.GetAllVehiclesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(context.Vehicles.Count(v => v.IsDeleted == false)));

            foreach (var model in result)
            {
                Assert.That(model, Is.InstanceOf<VehicleViewModel>());
            }

            foreach (var vehicle in context.Vehicles)
            {
                vehicle.IsDeleted = true;
            }

            await context.SaveChangesAsync();

            result = await vehicleService.GetAllVehiclesAsync();

            Assert.That(result, Is.Empty);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetVehicleDetailsModelAsyncShouldReturnModel(int id)
        {
            var result = await vehicleService.GetVehicleDetailsModelAsync(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<VehicleDetailsViewModel>());
            Assert.That(result.Manufacturer, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);

        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(3)]
        [TestCase(10)]
        public async Task GetVehicleDetailsModelAsyncShouldReturnNullWhenIdIsIncorrect(int id)
        {
            var result = await vehicleService.GetVehicleDetailsModelAsync(id);

            Assert.That(result, Is.Null);
            Assert.That(result?.Manufacturer, Is.Null);
            Assert.That(result?.Type, Is.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetVehicleDeleteModelAsyncShouldReturnModel(int id)
        {
            var result = await vehicleService.GetVehicleDeleteModelAsync(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<VehicleDeleteViewModel>());
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        public async Task GetVehicleDeleteModelAsyncShouldReturnNullWhenIdIsIncorrectOrEntityIsDeleted(int id)
        {
            var result = await vehicleService.GetVehicleDeleteModelAsync(id);

            Assert.That(result, Is.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task DeleteVehicleAsyncShouldReturnTrueAndUpdateThisEntity(int id)
        {
            var result = await vehicleService.DeleteVehicleAsync(id);

            Assert.That(result, Is.True);

            var deletedEntity = await context.Vehicles.FindAsync(id);

            Assert.That(deletedEntity?.IsDeleted, Is.True);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        public async Task DeleteVehicleAsyncShouldReturnFalseWhenIdIsIncorrectOrEntityIsDeleted(int id)
        {
            var result = await vehicleService.DeleteVehicleAsync(id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateNewVehicleAsyncShouldReturnTrueAndAddNewEntity()
        {
            var model = new VehicleCreateInputModel
            {
                RegistrationNumber = "CB 4444 CB",
                Vin = "4444444444",
                ManufacturerId = 1,
                VehicleModel = "New Model",
                FirstRegistration = "04-04-2024",
                EuroClass = EuroClass.Euro1,
                VehicleTypeId = 1,
                BodyType = BodyType.Curtain,
                Axles = 2,
                WeightCapacity = 1.64,
                AcquiredOn = "04-04-2024",
                LiabilityInsurance = "040/LEV/4444444444-44",
            };

            var result = await vehicleService.CreateNewVehicleAsync(model);

            Assert.That(result, Is.True);

            var totalVehicles = await context.Vehicles.CountAsync();

            Assert.That(totalVehicles, Is.EqualTo(4));
        }

        [Test]
        public async Task CreateNewVehicleAsyncShouldReturnFalseIfEntityWithSameRegistrationNumberExists()
        {
            var model = new VehicleCreateInputModel
            {
                RegistrationNumber = "CB 1111 CB",
                Vin = "4444444444",
                ManufacturerId = 1,
                VehicleModel = "New Model",
                FirstRegistration = "04-04-2024",
                EuroClass = EuroClass.Euro1,
                VehicleTypeId = 1,
                BodyType = BodyType.Curtain,
                Axles = 2,
                WeightCapacity = 1.64,
                AcquiredOn = "04-04-2024",
                LiabilityInsurance = "040/LEV/4444444444-44",
            };

            var result = await vehicleService.CreateNewVehicleAsync(model);

            Assert.That(result, Is.False);

            var totalVehicles = await context.Vehicles.CountAsync();

            Assert.That(totalVehicles, Is.EqualTo(3));
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetVehicleEditModelAsyncShouldReturnVehicleEditInputModel(int id)
        {
            var model = await vehicleService.GetVehicleEditModelAsync(id);

            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.TypeOf<VehicleEditInputModel>());
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        public async Task GetVehicleEditModelAsyncShouldReturnNullIfIdDoesNotExistsOrEntityIsDeleted(int id)
        {
            var model = await vehicleService.GetVehicleEditModelAsync(id);

            Assert.That(model, Is.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task EditVehicleShouldReturnTrueAndUpdateThisEntity(int id)
        {
            var model = new VehicleEditInputModel
            {
                Id = id,
                RegistrationNumber = "CB 4444 CB",
                Vin = "4444444444",
                ManufacturerId = 1,
                VehicleModel = "New Model",
                FirstRegistration = "04-04-2024",
                EuroClass = EuroClass.Euro1,
                VehicleTypeId = 1,
                BodyType = BodyType.Curtain,
                Axles = 2,
                WeightCapacity = 1.64,
                AcquiredOn = "04-04-2024",
                LiabilityInsurance = "040/LEV/4444444444-44",
            };

            var result = await vehicleService.EditVehicleAsync(model);

            Assert.That(result, Is.True);

            var vehicle = await context.Vehicles.FindAsync(model.Id);

            Assert.That(vehicle?.RegistrationNumber, Is.EqualTo(model.RegistrationNumber));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        public async Task EditVehicleShouldReturnFalseWhenIdDoesNotExistsOrEntityIsDeleted(int id)
        {
            var model = new VehicleEditInputModel
            {
                Id = id,
                RegistrationNumber = "CB 4444 CB",
                Vin = "4444444444",
                ManufacturerId = 1,
                VehicleModel = "New Model",
                FirstRegistration = "04-04-2024",
                EuroClass = EuroClass.Euro1,
                VehicleTypeId = 1,
                BodyType = BodyType.Curtain,
                Axles = 2,
                WeightCapacity = 1.64,
                AcquiredOn = "04-04-2024",
                LiabilityInsurance = "040/LEV/4444444444-44",
            };

            var result = await vehicleService.EditVehicleAsync(model);

            Assert.That(result, Is.False);
        }

        private void MockConfig()
        {
            mockRepository.Setup(repo => repo.GetAllAsIQueryable())
                .Returns(context.Vehicles);

            mockRepository.Setup(repo => repo.GetWhereAsIQueryable(It.IsAny<Expression<Func<Vehicle, bool>>>()))
                .Returns((Expression<Func<Vehicle, bool>> predicate) => context.Vehicles.Where(predicate));

            mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .Returns((int id) => Task.Run(async () => await context.Vehicles.FindAsync(id)));

            mockRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Vehicle>()))
                .Returns((Vehicle entity) =>
                {
                    return Task.Run(async () =>
                    {
                        var entry = context.Entry(entity);

                        if (entry.State == EntityState.Detached)
                        {
                            context.Vehicles.Attach(entity);
                        }

                        context.Vehicles.Update(entity);
                        return await context.SaveChangesAsync() > 0;
                    });
                });

            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Vehicle>()))
                .Returns((Vehicle entity) =>
                {
                    return Task.Run(async () =>
                    {
                        await context.Vehicles.AddAsync(entity);
                        return await context.SaveChangesAsync() > 0;
                    });
                });

        }

        private async Task SeedInMemoryDatabase()
        {
            context.Vehicles.RemoveRange(context.Vehicles);
            context.Manufacturers.RemoveRange(context.Manufacturers);
            context.VehicleTypes.RemoveRange(context.VehicleTypes);
            await context.SaveChangesAsync();

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
                    VehicleType= new VehicleType{Id = 1, Type = "First"},
                    BodyType = BodyType.Curtain,
                    Axles = 2,
                    WeightCapacity = 1.64,
                    AcquiredOn = new DateTime(2024, 01, 01),
                    LiabilityInsurance = "010/LEV/1111111111-11",
                    LiabilityInsuranceExpirationDate = new DateTime(2025, 01, 01)
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
                    VehicleType= new VehicleType{Id = 2, Type = "Second"},
                    BodyType = BodyType.Box,
                    Axles = 2,
                    WeightCapacity = 4.7,
                    AcquiredOn = new DateTime(2024, 02, 02),
                    LiabilityInsurance = "020/LEV/2222222222-22",
                    LiabilityInsuranceExpirationDate = new DateTime(2025, 02, 02),
                    TechnicalReviewExpirationDate = new DateTime(2025, 02, 02)
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
                    BodyType = BodyType.Frigo,
                    Axles = 3,
                    WeightCapacity = 9,
                    AcquiredOn = new DateTime(2024, 03, 03),
                    LiabilityInsurance = "030/LEV/3333333333-33",
                    LiabilityInsuranceExpirationDate = new DateTime(2025, 03, 03),
                    TachographExpirationDate = new DateTime(2025, 03, 03),
                    IsDeleted = true
                }
            };

            context.Vehicles.AddRange(vehicles);
            await context.SaveChangesAsync();
        }
    }
}
