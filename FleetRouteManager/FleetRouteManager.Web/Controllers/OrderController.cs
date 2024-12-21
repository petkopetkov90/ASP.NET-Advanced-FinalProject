using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.OrderInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FleetRouteManager.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IClientService clientService;

        public OrderController(IOrderService orderService, IClientService clientService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> Index()
        {
            var model = await orderService.GetAllOrdersAsync();

            return View(model);
        }

        [HttpGet("Order Details")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await orderService.GetOrderDetailsAsync(id);

            if (model == null)
            {
                TempData["OrderError"] = "Order was not found.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Order Details Partial")]
        public async Task<IActionResult> DetailsPartial(int id)
        {
            var model = await orderService.GetOrderDetailsAsync(id);

            if (model == null)
            {

                return PartialView("_Error404");
            }

            return PartialView(model);
        }

        [HttpGet("Delete Order")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await orderService.GetOrderDeleteModelAsync(id);

            if (model == null)
            {
                TempData["OrderError"] = "Order was not found.";
                return RedirectToAction("Index");
            }

            if (User.Identity?.Name != "admin@myapp.com" && model.User != User.Identity?.Name)
            {
                TempData["OrderError"] = "Order can be deleted by current order manager.";
                return RedirectToAction("Index");
            }

            var returnUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View("DeleteConfirmation", model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Delete Order")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var user = User.Identity?.Name;

            if (await orderService.DeleteOrderAsync(id, user))
            {
                TempData["OrderSucceed"] = "Order was deleted successfully.";
            }
            else
            {
                TempData["OrderError"] = "Something went wrong.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Create New Order")]
        public async Task<IActionResult> Create()
        {

            await SetViewBagSelectListsAsync();
            var model = new OrderCreateInputModel
            {
                User = User.Identity!.Name!
            };

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Create New Order")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateInputModel model)
        {
            if (model.User != User.Identity!.Name!)
            {
                TempData["OrderError"] = "An unexpected error occurred.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                TempData["OrderError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            try
            {
                await orderService.CreateNewOrderAsync(model);
                TempData["OrderSucceed"] = "Order was created successfully.";
            }
            catch (CustomExistingEntityException e)
            {
                TempData["OrderError"] = e.Message;
            }
            catch (Exception)
            {
                TempData["OrderError"] = "An unexpected error occurred.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Edit Order")]
        public async Task<IActionResult> Edit(int id)
        {

            await SetViewBagSelectListsAsync();

            var model = await orderService.GetOrderEditModelAsync(id);

            if (model is null)
            {
                TempData["OrderError"] = "Order was not found.";
                return RedirectToAction("Index");
            }
            if (model.TripId != null)
            {
                TempData["OrderError"] = $"Order has already been fulfilled with trip {model.TripId}.";
                return RedirectToAction("Details", new { model.Id });
            }

            if (User.Identity!.Name! != "admin@myapp.com" && model.User != User.Identity!.Name!)
            {
                TempData["OrderError"] = "Changes can be made only by current order manager.";
                return RedirectToAction("Details", new { model.Id });
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("Edit Order")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderEditInputModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["OrderError"] = "There were validation errors.";

                await SetViewBagSelectListsAsync();
                return View(model);
            }

            if (model.TripId != null)
            {
                TempData["OrderError"] = $"Order has already been fulfilled with trip {model.TripId}.";
                return RedirectToAction("Details", new { model.Id });
            }

            var user = User.Identity?.Name;

            try
            {
                if (await orderService.EditOrderAsync(model, user))
                {
                    TempData["OrderSucceed"] = "Order was edited successfully.";
                    return RedirectToAction("Details", new { model.Id });
                }
                else
                {
                    TempData["OrderError"] = "Order was not found.";
                }
            }
            catch (CustomExistingEntityException e)
            {
                TempData["OrderError"] = e.Message;
            }
            catch (UnauthorizedAccessException)
            {
                TempData["OrderError"] = "Changes can be made only by current order manager.";
                return RedirectToAction("Details", new { model.Id });
            }
            catch (Exception)
            {
                TempData["OrderError"] = "An unexpected error occurred.";
            }


            return RedirectToAction("Index");
        }


        private async Task SetViewBagSelectListsAsync()
        {
            ViewBag.Clients = new SelectList(await clientService.GetClientViewBagListAsync(), "Id", "Name");
        }
    }
}
