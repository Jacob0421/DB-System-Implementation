using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.Models
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Customer Add(Customer customerIn)
        {
            _context.Customers.Add(customerIn);
            _context.SaveChanges();
            return customerIn;
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUserName(string usernameIn)
        {
            throw new NotImplementedException();
        }
    }
}
