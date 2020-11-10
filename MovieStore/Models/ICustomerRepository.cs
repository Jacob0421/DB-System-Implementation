using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        Customer Add(Customer customerIn);
        Customer Delete(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByUserName(string usernameIn);
    }
}
