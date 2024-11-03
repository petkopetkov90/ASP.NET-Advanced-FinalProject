using FleetRouteManager.Data.Models.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Web.Controllers
{
    //[Authorize]
    public class VehicleController : Controller
    {
        private readonly ISoftDeleteRepository<Vehicle, int> repository;

        public VehicleController(ISoftDeleteRepository<Vehicle, int> repository)
        {
            this.repository = repository;
        }

        [HttpGet("Vehicles")]
        public async Task<IActionResult> Index()
        {

            var vehicles = await repository.GetAllAsIQueryable()
                .AsNoTracking()
                .Select(v => new VehicleViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Vin = v.Vin,
                    Manufacturer = v.Manufacturer.Name,
                    Model = v.Model,
                    FirstRegistrationDate = v.FirstRegistration,
                    EuroClass = v.EuroClass,
                    TruckType = v.VehicleType.TypeName

                })
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();

            return View(vehicles);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
