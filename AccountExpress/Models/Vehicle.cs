using AccountExpress.Models.Enums;

namespace AccountExpress.Models
{
    public class Vehicle
    {
        public VehicleBrands Brands { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public string Exchange { get; set; }
        public string Steering { get; set; }
        public string Manufacturing { get; set; }

    }
}
