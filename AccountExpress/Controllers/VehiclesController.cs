using Microsoft.AspNetCore.Mvc;
using AccountExpress.Models;
using System.Collections.Generic;
using AccountExpress.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using AccountExpress.Models.Enums;
using System.Linq;
using AccountExpress.Models.Extensions;
using System.Threading.Tasks;

namespace AccountExpress.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(_vehicleService.Get());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.VehicleDoors = _vehicleService.Get().FirstOrDefault(v => v.Id == id).Doors.ObterDescricao();
            ViewBag.VehicleManufacturing = _vehicleService.Get().FirstOrDefault(m => m.Id == id).Manufacturing.ObterDescricao();
            ViewBag.Exchange = _vehicleService.Get().FirstOrDefault(m => m.Id == id).Exchange.ObterDescricao();


            return View(_vehicleService.Get(id));
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewBag.VehicleBrands = new SelectList(Enum.GetValues(typeof(VehicleBrands)).Cast<VehicleBrands>().Select(vb => new SelectListItem
            {
                Text = vb.ToString(),
                Value = ((int)vb).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleType = new SelectList(Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().Select(vt => new SelectListItem
            {
                Text = vt.ToString(),
                Value = ((int)vt).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleDoors = new SelectList(Enum.GetValues(typeof(VehicleDoors)).Cast<VehicleDoors>().Select(vd => new SelectListItem
            {
                Text = ((int)vd).ToString(),
                Value = ((int)vd).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleFuel = new SelectList(Enum.GetValues(typeof(VehicleFuel)).Cast<VehicleFuel>().Select(vf => new SelectListItem
            {
                Text = vf.ToString(),
                Value = ((int)vf).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleExchange = new SelectList(Enum.GetValues(typeof(VehicleExchange)).Cast<VehicleExchange>().Select(ve => new SelectListItem
            {
                Text = ve.ObterDescricao(),
                Value = ((int)ve).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleSteering = new SelectList(Enum.GetValues(typeof(VehicleSteering)).Cast<VehicleSteering>().Select(vs => new SelectListItem
            {
                Text = vs.ToString(),
                Value = ((int)vs).ToString()
            }).ToList(), "Value", "Text");

            ViewBag.VehicleManufacturing = new SelectList(Enum.GetValues(typeof(VehicleManufacturing)).Cast<VehicleManufacturing>().Select(vm => new SelectListItem
            {
                Text = vm.ObterDescricao(),
                Value = ((int)vm).ToString()
            }).ToList(), "Value", "Text");

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                _vehicleService.Post(vehicle);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            //var vehicle = await _context.Vehicles.FindAsync(id);
            var vehicle = _vehicleService.Get(id);

            ViewBag.vehicleBrandEdit = new SelectList(Enum.GetValues(typeof(VehicleBrands)).Cast<VehicleBrands>().Select(vm => new SelectListItem
            {
                Text = vm.ObterDescricao(),
                Value = ((int)vm).ToString(),
                Selected = vm == vehicle.Brands
            }).ToList(), "Value", "Text");

            ViewBag.vehicleTypeEdit = new SelectList(Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().Select(vt => new SelectListItem
            {
                Text = vt.ObterDescricao(),
                Value = ((int)vt).ToString(),
                Selected = vt == vehicle.Type
            }).ToList(), "Value", "Text");

            ViewBag.vehicleDoorsEdit = new SelectList(Enum.GetValues(typeof(VehicleDoors)).Cast<VehicleDoors>().Select(vd => new SelectListItem
            {
                Text = vd.ObterDescricao(),
                Value = ((int)vd).ToString(),
                Selected = vd == vehicle.Doors
            }).ToList(), "Value", "Text");

            ViewBag.vehicleFuelEdit = new SelectList(Enum.GetValues(typeof(VehicleFuel)).Cast<VehicleFuel>().Select(vf => new SelectListItem
            {
                Text = vf.ObterDescricao(),
                Value = ((int)vf).ToString(),
                Selected = vf == vehicle.Fuel
            }).ToList(), "Value", "Text");

            ViewBag.vehicleExchangeEdit = new SelectList(Enum.GetValues(typeof(VehicleExchange)).Cast<VehicleExchange>().Select(ve => new SelectListItem
            {
                Text = ve.ObterDescricao(),
                Value = ((int)ve).ToString(),
                Selected = ve == vehicle.Exchange
            }).ToList(), "Value", "Text");

            ViewBag.vehicleSteeringEdit = new SelectList(Enum.GetValues(typeof(VehicleSteering)).Cast<VehicleSteering>().Select(ve => new SelectListItem
            {
                Text = ve.ObterDescricao(),
                Value = ((int)ve).ToString(),
                Selected = ve == vehicle.Steering
            }).ToList(), "Value", "Text");

            ViewBag.vehicleManufacturingEdit = new SelectList(Enum.GetValues(typeof(VehicleManufacturing)).Cast<VehicleManufacturing>().Select(vm => new SelectListItem
            {
                Text = vm.ObterDescricao(),
                Value = ((int)vm).ToString(),
                Selected = vm == vehicle.Manufacturing
            }).ToList(), "Value", "Text");

            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            try
            {
                _vehicleService.Put(vehicle);

                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_vehicleService.Get(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rent rent)
        {
            try
            {
                _vehicleService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}