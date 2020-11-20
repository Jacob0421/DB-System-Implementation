using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieStore.Models;

namespace MovieStore.Models
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Add(User customerIn)
        {
            _context.Users.Add(customerIn);
            _context.SaveChanges();
            return customerIn;
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return _context.Users;
        }

        public User GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string customerIn)
        {
            return _context.Users.FirstOrDefault(u => u.UserUserName == customerIn);
        }

        public User GetRoleByUsername(string customerIn)
        {
            return _context.Users.FirstOrDefault(n => n.role == "admin");
        }
    }
}
