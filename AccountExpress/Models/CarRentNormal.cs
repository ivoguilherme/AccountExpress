using AccountExpress.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public class CarRentNormal : CarRent
    {
        public override double Calculate(Rent rent)
        {
            // Declaração das variáveis
            double daily = rent.Daily;
            double secure = 1.15;
            double result = 0;

            // Data
            TimeSpan date = rent.ReturnDate - rent.PickupDate;

            // Data convertida em Quantidade de dias (Inteiro)
            int days = (int)date.TotalDays;

            // Cálculo Normal: Valor Diária * Quantidade de dias + 15% de Seguro
            result = daily * days * secure;

            return result;
        }
    }
}
