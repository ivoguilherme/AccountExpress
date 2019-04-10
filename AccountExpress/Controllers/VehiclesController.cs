using Microsoft.AspNetCore.Mvc;
using AccountExpress.Models.Enums;
using System;
using System.Linq;

namespace AccountExpress.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult VehicleRegistration()
        {
            return View();
        }

        public IActionResult VehicleManager()
        {
            return View();
        }
    }
}