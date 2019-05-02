using AccountExpress.Data;
using AccountExpress.Interfaces;
using AccountExpress.Models;

namespace AccountExpress.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
