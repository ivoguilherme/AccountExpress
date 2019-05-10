using AccountExpress.Models.Enums;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AccountExpress.Models.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleBrands Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public string Exchange { get; set; }
        public string Steering { get; set; }
        public string Manufacturing { get; set; }
        public List<SelectListItem> ListBrands { get; set; }
    }
}
