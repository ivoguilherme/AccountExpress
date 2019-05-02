﻿using AccountExpress.Interfaces;
using AccountExpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountExpress.Controllers
{
    public class RentsController : Controller
    {
        private readonly IRentRepository _rentRepository;
        public RentsController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(_rentRepository.GetAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(_rentRepository.GetById(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rent rent)
        {
            try
            {
                _rentRepository.Add(rent);

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
            return View(_rentRepository.GetById(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rent rent)
        {
            try
            {
                _rentRepository.Update(rent);

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
            return View(_rentRepository.GetById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rent rent)
        {
            try
            {
                _rentRepository.Remove(_rentRepository.GetById(id));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    /*public class RentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
            Rent[] rentsModel = await _context.Rent.Include(r => r.Vehicle).Include(r => r.Customer).ToArrayAsync();
            var rentsViewModel = rentsModel.Select(rent => RentMapper.ModelToViewModel(rent)).ToArray();
            return View(rentsViewModel);
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            IEnumerable<Customer> customers = _context.Customers.ToArray();
            ViewBag.Customers = customers.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();

            IEnumerable<Vehicle> vehicles = _context.Vehicles.ToArray();
            ViewBag.Vehicles = vehicles.Select(v => new SelectListItem() { Text = string.Concat(v.Brands, " - ", v.Model), Value = v.Id.ToString() }).ToList();

            ViewBag.RentType = new SelectList(Enum.GetValues(typeof(RentType)).Cast<RentType>().Select(v => new SelectListItem
            {
                Text = v.ObterDescricao(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");
            return View();
        }//

        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,VehicleId,PickupDate,ReturnDate,TypeOfRent,Daily,DelayRate")] Rent rent)
        {
            if (ModelState.IsValid)
            {

                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FindAsync(id);
            var customers = await _context.Customers.ToListAsync();
            var vehicles = await _context.Vehicles.ToListAsync();

            if (rent == null)
            {
                return NotFound();
            }
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCustomers,IdVehicles,PickupDate,ReturnDate,TypeOfRent,Daily,DelayRate")] Rent rent)
        {
            if (id != rent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Id))
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
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            _context.Rent.Remove(rent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rent.Any(e => e.Id == id);
        }
    }*/
}
