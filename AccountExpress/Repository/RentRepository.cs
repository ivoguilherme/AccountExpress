using AccountExpress.Data;
using AccountExpress.Interfaces;
using AccountExpress.Models;
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
    }
}
