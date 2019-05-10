using AccountExpress.Interfaces.Services;

namespace AccountExpress.Models.Base
{
    public abstract class CarRent : ICarRent
    {
        public abstract double Calculate(Rent rent);
    }
}
