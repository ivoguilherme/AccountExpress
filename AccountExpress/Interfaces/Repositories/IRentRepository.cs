using AccountExpress.Models;
using System.Collections.Generic;

namespace AccountExpress.Interfaces
{
    public interface IRentRepository : IRepository<Rent>
    {
        IEnumerable<Rent> GetWithCustomerAndVehicles();
    }
}
