using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActorRepository _actorList;
        private readonly IUserRepository _customerList;
        private readonly IMovieRepository _movieList;
        private readonly IPast_PurchasesRepository _past_purchaseList;
        private readonly IPurchaseRepository _purchaseList;
        private readonly IRentalRepository _rentalList;
        private readonly IReviewRepository _reviewList;
        private readonly ITransactionRepository _transactionList;
        private readonly IAge_RatingRepository _age_RatingList;
        private readonly IDirectorRepository _directorList;
        private readonly IGenreRepository _genreList;
        private readonly ICartRepository _cartList;
        private readonly ITransactionDetailsRepository _transactionDetailsList;
        private readonly AppDbContext _context;


        public HomeController(ILogger<HomeController> logger,
                           IActorRepository actor,
                           IUserRepository customer,
                           IMovieRepository movie,
                           IPast_PurchasesRepository past_purchase,
                           IPurchaseRepository purchase,
                           IRentalRepository rental,
                           IReviewRepository review,
                           ITransactionRepository transaction,
                           IAge_RatingRepository age_rating,
                           IDirectorRepository director,
                           IGenreRepository genre,
                           ICartRepository cart,
                           ITransactionDetailsRepository transactionDetails,
                           AppDbContext context
                           )
        {
            _logger = logger;
            _actorList = actor;
            _customerList = customer;
            _movieList = movie;
            _past_purchaseList = past_purchase;
            _purchaseList = purchase;
            _rentalList = rental;
            _reviewList = review;
            _transactionList = transaction;
            _age_RatingList = age_rating;
            _directorList = director;
            _genreList = genre;
            _cartList = cart;
            _transactionDetailsList = transactionDetails;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserHome()
        {
            return View();
        }

        public IActionResult CheckBalance()
        {
            return View();
        }
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(User CustomerIn)
        {
            _customerList.Add(CustomerIn);
            return RedirectToAction("UserList");
        }

        public IActionResult UserList()
        {
            return View(_customerList.GetAllCustomers().AsEnumerable());
        }

        public IActionResult ReviewList()
        {
            return View(_reviewList.GetAllReviews().AsEnumerable());
        }

        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(Review ReviewIn)
        {
            ReviewIn.Author = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            _reviewList.Add(ReviewIn);
            return RedirectToAction("ReviewList");
        }

        public IActionResult AdminHomepage()
        {
            return View(_movieList.GetAllMovies());
        }

        public IActionResult MovieList()
        {
            return View(_movieList.GetAllMovies());
        }

        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchMovie(string movieIn)
        {
            IEnumerable<Movie> results = _movieList.SearchMovies(movieIn);

            if (results != null)
            {
                ViewData.Model = results;

                return View("MovieSearchResults", results);
            }
            else
            {
                TempData["error"] = "Movie not Found: Please try again.";
                ViewData.Model = _movieList.GetAllMovies();
                return View("MovieSearch");
            }
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movieIn, string DirectorFName, string DirectorLName, string Genre, string AgeRating)
        {
            Genre matchedGenre = _genreList.GetGenreByName(Genre);

            if (matchedGenre != null)
                movieIn.Genre = matchedGenre;
            else
                movieIn.Genre = _genreList.AddGenre(Genre);

            Age_Rating matchedAge_Rating = _age_RatingList.GetAge_RatingByName(AgeRating);

            if (matchedAge_Rating != null)
                movieIn.AgeRating = matchedAge_Rating;
            else
                ViewBag.Result = "There was an error Selecting age rating please Try Again.";

            Director matchedDirector = _directorList.GetDirectorByName(DirectorFName, DirectorLName);

            if (matchedDirector != null)
                movieIn.Director = matchedDirector;
            else
                movieIn.Director = _directorList.AddDirector(DirectorFName, DirectorLName);

            _movieList.Add(movieIn);

            return RedirectToAction("AdminHomepage");
        }

        public IActionResult CustomerHomepage()
        {
            return View(_movieList.GetAllMovies());
        }

        [HttpGet]
        public IActionResult AddRental(int movieId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            Movie movieIn = _movieList.GetMovie(movieId);
            _cartList.AddToCart(movieIn, currentUser, true);

            ViewBag.Result = "Rental Successfully Added";
            return RedirectToAction("CustomerHomepage");
        }

        [HttpGet]
        public IActionResult AddPurchase(int movieId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            Movie movieIn = _movieList.GetMovie(movieId);
            _cartList.AddToCart(movieIn, currentUser, false);

            ViewBag.Result = "Purchase Successfully Added";
            return RedirectToAction("CustomerHomepage");
        }

        public IActionResult DisplayCart()
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (foundUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(foundUser);
                decimal cartTotal = 0;
                foreach (var cartItem in userCart)
                {
                    cartTotal += _cartList.getMoviePrice(cartItem.Movie, cartItem.IsRental);
                }
                foundUser.UserCartTotal = cartTotal;

                ViewBag.Total = cartTotal.ToString();
                ViewBag.UserNum = foundUser.UserNum;
                return View(userCart);
            }
            else
                return RedirectToAction("CustomerHomepage");
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int cartId)
        {
            Cart foundCartItem = _cartList.GetCartItemById(cartId);

            _cartList.RemoveFromCart(foundCartItem);
            _context.SaveChanges();
            return RedirectToAction("DisplayCart");
        }

        public IActionResult DisplayCheckout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionDetails inputDetails)
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(foundUser);
            foreach (var Item in userCart)
            {
                if (Item.Movie.MovieInventory == 0)
                {
                    ViewBag.Result = Item.Movie.MovieTitle + " Is not longer in stock, please remove from cart or try again at a later date.";
                    return RedirectToAction("DisplayCart");
                }
            }
            foreach (var cartItem in userCart)
            {

                Transaction newTransaction = _transactionList.CreateTransaction(cartItem.Movie, foundUser, cartItem.IsRental);
                _transactionDetailsList.AddTransactionDetails(inputDetails, newTransaction);

                if (cartItem.IsRental)
                {
                    _rentalList.AddRental(newTransaction);
                }
                else
                {
                    _purchaseList.AddPurchase(newTransaction);

                };
            };
            _context.SaveChanges();
            return RedirectToAction("DisplayOrderConfirmation");
        }

        public IActionResult DisplayOrderConfirmation()
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (foundUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(foundUser);
                decimal cartTotal = 0;
                foreach (var cartItem in userCart)
                {
                    cartTotal += _cartList.getMoviePrice(cartItem.Movie, cartItem.IsRental);
                }
                foundUser.UserCartTotal = cartTotal;

                ViewBag.Total = foundUser.UserCartTotal.ToString();
                return View(userCart);
            }
            else
                return View("Login");
        }

        public IActionResult Orderconfirmed()
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (foundUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(foundUser);
                foreach (var cartItem in userCart)
                {
                    _cartList.RemoveFromCart(cartItem);
                }
                foundUser.AmountPaid = foundUser.UserCartTotal;
                foundUser.UserCartTotal = 0;
                _context.SaveChanges();

                return RedirectToAction("CustomerHomepage");
            }
            return View("Index");
        }

        public IActionResult CancelledOrders()
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (foundUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(foundUser);

                foreach (var cartItem in userCart)
                {
                    _cartList.RemoveFromCart(cartItem);
                }
                _context.SaveChanges();

                return RedirectToAction("CustomerHomepage");
            }
            return View("Index");
        }

        public IActionResult ReturnRental()
        {
            User foundUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if(foundUser != null)
            {
                IEnumerable<Rental> OutstandingUserRentals = _rentalList.GetOutstandingUserRentals(foundUser);
                foreach(var rental in OutstandingUserRentals)
                {
                    var rentalDueDate = DateTime.Parse(rental.DueDate);
                    if (rentalDueDate < DateTime.Today)
                    {
                        rental.IsLate = true;
                        rental.DaysLate = (int)(DateTime.Today.Subtract(rentalDueDate).TotalDays);
                    }
                }
                return View(OutstandingUserRentals);
            }else
                return View("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User foundUser = _customerList.GetUserByUsername(username);
            if (foundUser != null && foundUser.role != null)
            {

                if (foundUser.UserUserName.Equals(username) && foundUser.role.Equals("admin"))
                {
                    return RedirectToAction("AdminHomepage");
                }
                else if (foundUser.UserUserName.Equals(username) && foundUser.role != "admin")
                {
                    HttpContext.Session.SetString("Username", username);
                    return RedirectToAction("CustomerHomepage");
                }
                else
                    ViewBag.Result = "Something Went Wrong...";
            }
            else
                ViewBag.Result = "Invalid Username.";
            return View();
        }
    }
}
