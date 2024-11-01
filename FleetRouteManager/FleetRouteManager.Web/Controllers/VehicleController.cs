using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    //[Authorize]
    public class VehicleController : Controller
    {
        [HttpGet("Vehicles")]
        public IActionResult Index()
        {
            var vehicles = new List<VehicleViewModel>
            {
                new VehicleViewModel
                {
                    Id = 1,
                    RegistrationNumber = "CB 1111 CB",
                    Vin = "MAN1111111111",
                    Manufacturer = "Man",
                    Model = "TGL",
                    FirstRegistrationDate = "21/12/2015",
                    EuroClass = "Euro 5",
                    TruckType = "Solo 7.5t"
                },
                new VehicleViewModel
                {
                    Id = 2,
                    RegistrationNumber = "CB 2222 CB",
                    Vin = "MAN2222222",
                    Manufacturer = "Renault",
                    Model = "Premium",
                    FirstRegistrationDate = "11/05/2018",
                    EuroClass = "Euro 6",
                    TruckType = "Solo 7.5t"
                },
                new VehicleViewModel
                {
                    Id = 3,
                    RegistrationNumber = "CB 3333 CB",
                    Vin = "MAN333333333",
                    Manufacturer = "Mercedes",
                    Model = "Atego",
                    FirstRegistrationDate = "04/09/2021",
                    EuroClass = "Euro 6",
                    TruckType = "Solo 12.0t"
                }
            };

            return View(vehicles);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
