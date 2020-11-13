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
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<Rental> Rentals{ get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Actor> Actors { get; set; }
        //public DbSet<MOVIE_has_ACTOR> MOVIE_Has_ACTORS { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<Review> Reviews { get; set; }

    }
}
