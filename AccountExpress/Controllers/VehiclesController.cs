using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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