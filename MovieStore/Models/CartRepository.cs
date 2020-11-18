using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository (AppDbContext context)
        {
            _context = context;
        }

        public Cart AddToCart(Movie addedToCart, User customerIn, bool isRentalIn)
        {
            Cart newCart = new Cart()
            {
                Movie = addedToCart,
                CartOwner = customerIn,
                IsRental = isRentalIn
            };
            _context.Add(newCart);
            _context.SaveChanges();

            return newCart;
        }

        public IEnumerable<Cart> GetCartItemsByUser(User userIn)
        {
            return _context.Carts.Include(c => c.CartOwner).Include(c => c.Movie).Where(c => c.CartOwner.UserNum == userIn.UserNum);
        }

        public Cart RemoveFromCart(Cart cartItemIn)
        {
            _context.Remove(cartItemIn);
            _context.SaveChanges();
            return cartItemIn;
        }

        public Cart GetCartItemById(int cartIdIn)
        {
            return _context.Carts.FirstOrDefault(c => c.CartId == cartIdIn);
        }
    }
}
