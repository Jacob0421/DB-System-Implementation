using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface IUserRepository
    {
        User GetCustomer(int id);
        User Add(User customerIn);
        User Delete(int id);
        IEnumerable<User> GetAllCustomers();
        User GetCustomerByUserName(string usernameIn);
    }
}
