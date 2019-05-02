using Microsoft.AspNetCore.Mvc;
using AccountExpress.Models.Enums;
using System;
using System.Linq;
using AccountExpress.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountExpress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountExpress.Models.Extensions;
using System.Collections.Generic;
using AccountExpress.Interfaces;

namespace AccountExpress.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(_vehicleRepository.GetAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(_vehicleRepository.GetById(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Add(vehicle);

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
            return View(_vehicleRepository.GetById(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Update(vehicle);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_vehicleRepository.GetById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rent rent)
        {
            try
            {
                _vehicleRepository.Remove(_vehicleRepository.GetById(id));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    /*public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: VCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brands,Chassis,Model,Type,Doors,Color,Fuel,Exchange,Steering,Manufacturing,Mileage,Observations,Plate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);

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

        // POST: Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brands,Chassis,Model,Type,Doors,Color,Fuel,Exchange,Steering,Manufacturing,Mileage,Observations,Plate")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }*/
}