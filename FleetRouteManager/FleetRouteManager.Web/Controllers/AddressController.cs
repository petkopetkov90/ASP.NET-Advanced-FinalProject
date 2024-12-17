using FleetRouteManager.Common.Exceptions;
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

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Add New Address")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddressCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["AddressFormError"] = "There were validation errors.";
            }

            else
            {
                try
                {
                    TempData["AddressId"] = await addressService.AddNewAddressAsync(model);
                    TempData["AddressSuccess"] = "Address was added successfully.";
                }
                catch (CustomExistingEntityException e)
                {
                    TempData["AddressError"] = e.Message;
                    TempData["AddressId"] = await addressService.GetAddressId(model);
                }
                catch (Exception)
                {
                    TempData["AddressError"] = "An unexpected error occurred.";
                }
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
