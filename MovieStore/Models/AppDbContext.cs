using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieStore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies{ get; set; }
    }
}
