using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using AccountExpress.Models.Enums;
using AccountExpress.Models.Extensions;
using AccountExpress.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountExpress.Controllers
{
    public class RentsController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        public RentsController(IRentService rentService, IVehicleService vehicleService, ICustomerService customerService)
        {
            _rentService = rentService;
            _vehicleService = vehicleService;
            _customerService = customerService;
        }

        // GET: Rents
        public ActionResult Index()
        {
            IEnumerable<Rent> rentsModel = _rentService.GetWithCustomerAndVehicles();
            var rentsViewModel = rentsModel.Select(rent => RentMapper.ModelToViewModel(rent)).ToArray();

            ViewBag.PickupDate = rentsViewModel.Select(pd => pd.PickupDate).FirstOrDefault().ToString("dd/MM/yyyy");
            ViewBag.ReturnDate = rentsViewModel.Select(pd => pd.ReturnDate).FirstOrDefault().ToString("dd/MM/yyyy");

            return View(rentsViewModel);
        }

        // GET: Rents/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Customer = _customerService.Get().FirstOrDefault(c => c.Id == _rentService.Get(id).CustomerId).Name;
            ViewBag.Vehicle = _vehicleService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).VehicleId).Model;
            ViewBag.TypeOfRent = _rentService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).Id).TypeOfRent.ObterDescricao();
            ViewBag.PickupDate = _rentService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).Id).PickupDate.ToString("dd/MM/yyyy");
            ViewBag.ReturnDate = _rentService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).Id).ReturnDate.ToString("dd/MM/yyyy");
            ViewBag.Daily = String.Format("{0:C}", _rentService.Get().FirstOrDefault(d => d.Id == _rentService.Get(id).Id).Daily);
            ViewBag.Location = String.Format("{0:C}", _rentService.Get().FirstOrDefault(d => d.Id == _rentService.Get(id).Id).Location);

            return View(_rentService.Get(id));
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            IEnumerable<Customer> customers = _customerService.Get();
            ViewBag.Customers = customers.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();

            IEnumerable<Vehicle> vehicles = _vehicleService.Get();
            ViewBag.Vehicles = vehicles.Where(v => v.isRented == false).Select(v => new SelectListItem() { Text = string.Concat(v.Brands, " - ", v.Model), Value = v.Id.ToString() }).ToList();

            ViewBag.RentType = new SelectList(
                Enum.GetValues(typeof(RentType)).Cast<RentType>().Select(v => new SelectListItem
                {
                    Text = v.ObterDescricao(),
                    Value = ((int)v).ToString()
                })
                .ToList(), "Value", "Text");

            return View();
        }

        // POST: Rents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rent rent)
        {
            try
            {
                _rentService.Post(rent);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                var teste = e.Message;
                return View();
            }
        }

        // GET: Rent/Edit/5
        public ActionResult Edit(int id)
        {
            var rent = _rentService.Get(id);

            IEnumerable<Customer> customers = _customerService.Get();
            ViewBag.Customers = new SelectList(customers, "Id", "Name", rent.CustomerId);

            IEnumerable<Vehicle> vehicles = _vehicleService.Get().Where(v => v.isRented == false);
            ViewBag.Vehicles = new SelectList(vehicles, "Id", "Model", rent.VehicleId);

            ViewBag.RentType = new SelectList(Enum.GetValues(typeof(RentType)).Cast<RentType>()
                .Select(v => new { Id = v, Text = v.ObterDescricao() })
                .ToList(), "Id", "Text", rent.TypeOfRent);

            return View(rent);

        }

        // POST: Rent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rent rent)
        {
            try
            {
                _rentService.Put(rent);

                return RedirectToAction(nameof(Details), new { id = id});
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Rent/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Customer = _customerService.Get().FirstOrDefault(c => c.Id == _rentService.Get(id).CustomerId);
            ViewBag.Vehicle = _vehicleService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).VehicleId);

            return View(_rentService.Get(id));
        }

        // POST: Rent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rent rent)
        {
            try
            {
                _rentService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Finalize
        public ActionResult Finalize(int id)
        {
            ViewBag.Customer = _customerService.Get().FirstOrDefault(c => c.Id == _rentService.Get(id).CustomerId);
            ViewBag.Vehicle = _vehicleService.Get().FirstOrDefault(v => v.Id == _rentService.Get(id).VehicleId);
            ViewBag.Daily = String.Format("{0:C}", _rentService.Get().FirstOrDefault(d => d.Id == _rentService.Get(id).Id).Daily);
            ViewBag.Location = String.Format("{0:C}", _rentService.Get().FirstOrDefault(d => d.Id == _rentService.Get(id).Id).Location);

            return View(_rentService.Get(id));
        }

        // POST: Finalize
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Finalize(int id, Rent rent)
        {
            try
            {
                _rentService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}
