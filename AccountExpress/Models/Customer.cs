using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CNH { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string AdressNumber { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
    }
}
