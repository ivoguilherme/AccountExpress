using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Services
{
    public class VehicleService : Service<Vehicle>, IVehicleService
    {
        public VehicleService(IRepository<Vehicle> repository) : base(repository)
        {

        }
    }
}
