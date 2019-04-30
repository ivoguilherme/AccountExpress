using AccountExpress.Models.Data;
using AccountExpress.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public class Rent : Entity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentType TypeOfRent { get; set; }
        public double Daily { get; set; }
        public double DelayRate { get; set; }
    }
}
