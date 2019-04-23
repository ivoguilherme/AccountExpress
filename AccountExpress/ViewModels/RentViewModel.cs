using AccountExpress.Models;
using AccountExpress.Models.Enums;
using AccountExpress.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.ViewModels
{
    public class RentViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string TypeOfRent { get; set; }
        public RentType TypeOfRentEnum { get; set; } // criei esse cara so para quando viewmodel virar model
        public double Daily { get; set; }
        public double DelayRate { get; set; }


    }

    public class RentMapper
    {

        public static RentViewModel ModelToViewModel(Rent rent)
        {
            RentViewModel rentVM = new RentViewModel()
            {
                CustomerId = rent.CustomerId,
                Customer = rent.Customer,
                VehicleId = rent.VehicleId,
                Vehicle = rent.Vehicle,
                PickupDate = rent.PickupDate,
                ReturnDate = rent.ReturnDate,
                TypeOfRent = rent.TypeOfRent.ObterDescricao(),
                TypeOfRentEnum = rent.TypeOfRent,
                Daily = rent.Daily,
                DelayRate = rent.DelayRate
            };

            return rentVM;
        }

        public static Rent ViewModelToModel(RentViewModel rentVM, Rent rent)
        {
            rent.CustomerId = rentVM.CustomerId;
            rent.Customer = rentVM.Customer;
            rent.VehicleId = rentVM.VehicleId;
            rent.Vehicle = rentVM.Vehicle;
            rent.PickupDate = rentVM.PickupDate;
            rent.ReturnDate = rentVM.ReturnDate;
            rent.TypeOfRent = rentVM.TypeOfRentEnum;
            rent.Daily = rentVM.Daily;
            rent.DelayRate = rentVM.DelayRate;

            return rent;
        }


    }
}
