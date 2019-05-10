using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using AccountExpress.Models.Calculations;
using System.Collections.Generic;

namespace AccountExpress.Services
{
    public class RentService : Service<Rent>, IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private CarRentNormal normal = new CarRentNormal();

        public RentService(IRepository<Rent> repository, IRentRepository rentRepository, IVehicleRepository vehicleRepository) : base(repository)
        {
            _rentRepository = rentRepository;
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Rent> GetWithCustomerAndVehicles()
        {
            return _rentRepository.GetWithCustomerAndVehicles();
        }

        public override Rent Get(int id)
        {
            var rent = _rentRepository.GetById(id);

            return rent;
        }

        public override Rent Post(Rent rent)
        {
            Vehicle vehicle = _vehicleRepository.GetById(rent.VehicleId);
            vehicle.isRented = true;

            _vehicleRepository.Update(vehicle);
            _rentRepository.Add(rent);

            return rent;
        }

        public override void Delete(int id)
        {
            Rent rent = _rentRepository.GetById(id);
            Vehicle vehicle = _vehicleRepository.GetById(rent.VehicleId);
            vehicle.isRented = false;

            _vehicleRepository.Update(vehicle);
            _rentRepository.Remove(_rentRepository.GetById(id));
        }

        public override Rent Put(Rent rent)
        {
            Rent rentClone = _rentRepository.GetById(rent.Id);

            if (rent.VehicleId != rentClone.VehicleId)
            {
                Vehicle vehicleNew = _vehicleRepository.GetById(rent.VehicleId);
                Vehicle vehicleOld = _vehicleRepository.GetById(rentClone.VehicleId);

                vehicleNew.isRented = true;
                vehicleOld.isRented = false;
                _vehicleRepository.Update(vehicleNew);
                _vehicleRepository.Update(vehicleOld);
            }

            return _rentRepository.Update(rent);
        }
    }
}
