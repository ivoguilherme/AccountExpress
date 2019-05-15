using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountExpress.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountExpress.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        public OverviewController(IRentService rentService, IVehicleService vehicleService, ICustomerService customerService)
        {
            _rentService = rentService;
            _vehicleService = vehicleService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalVehicles = _vehicleService.Get().Count();
            ViewBag.AvailableVehicles = _vehicleService.Get().Where(dv => dv.isRented == false).Count();
            ViewBag.UnavailableVehicles = _vehicleService.Get().Where(dv => dv.isRented == true).Count();

            ViewBag.TotalCustomers = _customerService.Get().Count();

            ViewBag.TotalRents = _rentService.Get().Count();

            return View();
        }
    }
}