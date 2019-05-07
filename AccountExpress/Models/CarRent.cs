using AccountExpress.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public abstract class CarRent : ICarRent
    {
        public abstract double Calculate(Rent rent);
        //public abstract double Calculate(double daily, DateTime pickupDate, DateTime returnDate);
    }
}
