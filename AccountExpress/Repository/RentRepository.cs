using AccountExpress.Data;
using AccountExpress.Interfaces;
using AccountExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Repository
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        private readonly ApplicationDbContext _context;

        public RentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Rent> GetWithCustomerAndVehicles()
        {
            return _context.Rent.Include(r => r.Vehicle).Include(r => r.Customer).ToArray();
        }
    }
}
