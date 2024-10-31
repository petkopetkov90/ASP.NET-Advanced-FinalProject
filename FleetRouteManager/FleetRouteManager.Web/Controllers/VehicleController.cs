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
                    RegistrationNumber = "CB1111CB",
                    Vin = "MAN1111111111",
                    Manufacturer = "MAN",
                    Model = "TGL",
                    FirstRegistrationDate = "21/12/2015",
                    EuroClass = "EURO 5"
                },
                new VehicleViewModel
                {
                    Id = 2,
                    RegistrationNumber = "CB2222CB",
                    Vin = "MAN2222222",
                    Manufacturer = "Renault",
                    Model = "Premium",
                    FirstRegistrationDate = "11/05/2018",
                    EuroClass = "EURO 6"
                },
                new VehicleViewModel
                {
                    Id = 3,
                    RegistrationNumber = "CB3333CB",
                    Vin = "MAN333333333",
                    Manufacturer = "Mercedes",
                    Model = "Atego",
                    FirstRegistrationDate = "04/09/2021",
                    EuroClass = "EURO 6"
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
