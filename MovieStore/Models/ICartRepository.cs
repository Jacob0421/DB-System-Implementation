using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public interface ICartRepository
    {
        Cart AddToCart(Movie addedToCart, User customerIn, bool isRentalIn);
        IEnumerable<Cart> GetCartItemsByUser(User userIn);
        Cart RemoveFromCart(Cart cartItemIn);
        Cart GetCartItemById(int cartIdIn);
    }
}
