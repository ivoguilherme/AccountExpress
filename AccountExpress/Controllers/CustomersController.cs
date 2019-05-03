using System.Collections.Generic;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountExpress.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //GET Customers
        public ActionResult Index()
        {
            return View(_customerService.Get());
        }


        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View(_customerService.Get(id));
        }


        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.Post(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Edit/5        
        public ActionResult Edit(int id)
        {
            return View(_customerService.Get(id));
        }

        // POST: Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _customerService.Put(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customerService.Get(id));
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _customerService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}