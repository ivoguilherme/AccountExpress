using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int IdCustomers { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public int IdVehicles { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string TypeOfRent { get; set; }
        public double Daily { get; set; }
        public double DelayRate { get; set; }
    }
}
