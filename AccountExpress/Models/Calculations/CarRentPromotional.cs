using AccountExpress.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models.Calculations
{
    public class CarRentPromotional : CarRent
    {
        private double Discount { get; set; }
        public override double Calculate(Rent rent)
        {
            Discount = 0.95;
            // Data
            TimeSpan date = rent.ReturnDate - rent.PickupDate;

            // Cálculo Normal: Valor Diária * Quantidade de dias * Desconto 5%
            double result = (rent.Daily * (date.TotalDays + 1)) * Discount;

            return result;
        }
    }
}
