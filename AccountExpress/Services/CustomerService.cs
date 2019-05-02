using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using AccountExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository) : base(repository)
        {

        }
    }
}
