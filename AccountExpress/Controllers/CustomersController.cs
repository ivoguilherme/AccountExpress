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
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }*/


        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View(_customerService.Get(id));
        }
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }*/


        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        /*public IActionResult Create()
        {
            return View();
        }*/

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
        /*public async Task<IActionResult> Create([Bind("Id,Name,Email,DateOfBirth,CPF,RG,CNH,Phone,Adress,AdressNumber,Complement,District,City,State,CEP")] Customer customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }*/


        // GET: Edit/5        
        public ActionResult Edit(int id)
        {
            return View(_customerService.Get(id));
        }
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }*/

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

        /*public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,DateOfBirth,CPF,RG,CNH,Phone,Adress,AdressNumber,Complement,District,City,State,CEP")] Customer customers)
        {
            if (id != customers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Id))
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
            return View(customers);
        }*/


        // GET: Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customerService.Get(id));
        }
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }*/

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
        /*public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }*/
    }
}