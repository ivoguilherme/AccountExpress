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
        private readonly IVehicleRepository _vehicleRepository;
        public RentService(IRepository<Rent> repository, IRentRepository rentRepository, IVehicleRepository vehicleRepository) : base(repository)
        {
            _rentRepository = rentRepository;
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Rent> GetWithCustomerAndVehicles()
        {
            return _rentRepository.GetWithCustomerAndVehicles();
        }

        public override Rent Post(Rent rent)
        {
            rent.Vehicle.isRented = true;

            _rentRepository.Add(rent);

            return rent;
        }

        public override void Delete(int id)
        {
            Rent rent = _rentRepository.GetById(id);
            Vehicle vehicle = _vehicleRepository.GetById(rent.VehicleId);
            vehicle.isRented = false;

            _rentRepository.Remove(_rentRepository.GetById(id));
        }

        public override Rent Put(Rent rent)
        {
            Vehicle vehicle = _vehicleRepository.GetById(rent.VehicleId);
            vehicle.isRented = false;

            return _rentRepository.Update(rent);
        }
    }
}
