using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpPost("Add New Address Modal")]
        public async Task<IActionResult> Add(AddressCreateInputModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData["AddressFormError"] = "There were validation errors";
            }

            else
            {
                TempData["NewAddressId"] = await addressService.AddNewAddressAsync(model);
            }

            var action = TempData["ReturnToAction"]?.ToString() ?? "Index";
            var controller = TempData["ReturnToController"]?.ToString() ?? "Home";
            var value = TempData["ReturnToValue"];

            if (value != null)
            {
                return RedirectToAction(action, controller, new { id = value });
            }

            return RedirectToAction(action, controller);
        }


    }
}
