using AccountExpress.Models.Data;
using AccountExpress.Models.Enums;

namespace AccountExpress.Models
{
    public class Vehicle : Entity
    {
        public VehicleBrands Brands { get; set; }
        public string Model { get; set; }
        public VehicleType Type { get; set; }
        public VehicleDoors Doors { get; set; }
        public string Color { get; set; }
        public VehicleFuel Fuel { get; set; }
        public VehicleExchange Exchange { get; set; }
        public VehicleSteering Steering { get; set; }
        public VehicleManufacturing Manufacturing { get; set; }
        public string Mileage { get; set; }
        public string Plate { get; set; }
        public string Chassis { get; set; }
        public string Observations { get; set; }
               
    }
}
