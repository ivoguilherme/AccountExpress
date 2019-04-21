using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
