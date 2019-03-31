using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountExpress.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult CustomerRegistration()
        {
            return View();
        }
    }
}