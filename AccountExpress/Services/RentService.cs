using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Services
{
    public class RentService : Service<Rent>, IRentService
    {
        private readonly IRentRepository _rentRepository;
        public RentService(IRepository<Rent> repository, IRentRepository rentRepository) : base(repository)
        {
            _rentRepository = rentRepository;
        }

        public IEnumerable<Rent> GetWithCustomerAndVehicles()
        {
            return _rentRepository.GetWithCustomerAndVehicles();
        }
    }
}
