using AccountExpress.Models.Base;
using System;

namespace AccountExpress.Models.Calculations
{
    public class CarRentNormal : CarRent
    {
        public override double Calculate(Rent rent)
        {
            // Data
            TimeSpan date = rent.ReturnDate - rent.PickupDate;

            // Cálculo Normal: Valor Diária * Quantidade de dias
            double result = rent.Daily * date.TotalDays;

            return result;
        }
    }
}
