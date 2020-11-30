using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MovieStore.Migrations;
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
            IEnumerable<Movie> topThreeMovies = _movieList.GetAllMovies().OrderByDescending(m => m.MovieRating).Take(3);
            ViewBag.NewAdditions = _movieList.GetAllMovies().Where(m => m.IsNewRelease).Take(3).ToList();
            return View(topThreeMovies);
        }

        public IActionResult CheckBalance()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                IEnumerable<Rental> userPastDueRentals = _rentalList.GetOutstandingUserRentals(currentUser).Where(r => r.IsLate);

                ViewBag.UserBalance = currentUser.AmountOwed;
                return View(userPastDueRentals);
            }
            else
            {
                return View("Login");
            }
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
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                if (TempData["Failure"] != null)
                {
                    ViewBag.Failure = TempData["Failure"];
                }

                IEnumerable<SelectListItem> movies = _context.Movies.Select(m => new SelectListItem
                {
                    Value = m.MovieNum.ToString(),
                    Text = m.MovieTitle
                });

                ViewBag.movieItems = movies;

                return View();
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public IActionResult AddReview(Review ReviewIn, string movieItems)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                ReviewIn.Author = currentUser;
                ReviewIn.Movie = _movieList.GetMovie(int.Parse(movieItems));
                ReviewIn.MovieTitle = ReviewIn.Movie.MovieTitle;
                if (ReviewIn.Movie == null)
                {
                    TempData["Failure"] = "The name: " + ReviewIn.MovieTitle + "was not found, please re-enter";
                    return RedirectToAction("AddReview");
                }
                _reviewList.Add(ReviewIn);
                IEnumerable<Review> movieReviews = _reviewList.GetMovieReviews(ReviewIn.Movie);

                ReviewIn.Movie.MovieRating = Math.Round((decimal)movieReviews.Average(m => m.StarRating));

                ReviewIn.Movie.NumberOfReviews = movieReviews.Count();
                _context.SaveChanges();
                return RedirectToAction("ReviewList");
            }
            else
            {
                return View("Login");
            }
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
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                if (TempData["Result"] != null)
                    ViewBag.Result = TempData["Result"];
                if (TempData["Failure"] != null)
                    ViewBag.Failure = TempData["Failure"];
                return View(_movieList.GetAllMovies());
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public IActionResult AddRental(int movieId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            Movie movieIn = _movieList.GetMovie(movieId);

            IEnumerable<Rental> userRentals = _rentalList.GetOutstandingUserRentals(currentUser);
            IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);

            bool alreadyInCart = false;
            foreach (var cartItem in userCart)
            {
                if (cartItem.Movie.Equals(movieIn))
                {
                    alreadyInCart = true;
                    break;
                }
            }


            if (!alreadyInCart)
            {
                int numOfOutstandingRentals = userRentals.Count();
                if (numOfOutstandingRentals < 2)
                {
                    int numOfPendingRentals = userCart.Where(c => c.IsRental == true).Count();
                    if ((numOfPendingRentals + numOfOutstandingRentals) < 2)
                    {
                        _cartList.AddToCart(movieIn, currentUser, true);
                        currentUser.UserCartTotal += movieIn.RentalPrice;
                        _context.SaveChanges();
                        TempData["Result"] = movieIn.MovieTitle + " was successfully added to your cart";
                    }
                    else
                    {
                        TempData["Failure"] = movieIn.MovieTitle + " was NOT added to your cart. \n" +
                                                                   "You can only have two rentals at a time";
                    }
                }
                else
                {
                    TempData["Failure"] = movieIn.MovieTitle + " was NOT added to your cart. \n" +
                                                               "You can only have two rentals at a time";
                }
            }
            else
            {
                TempData["Failure"] = movieIn.MovieTitle + " is already in your cart.";
            }
            return RedirectToAction("CustomerHomepage");
        }

        [HttpGet]
        public IActionResult AddPurchase(int movieId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            Movie movieIn = _movieList.GetMovie(movieId);
            IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);
            bool alreadyInCart = false;

            foreach (var cartItem in userCart)
            {
                if (cartItem.Movie.Equals(movieIn))
                {
                    alreadyInCart = true;
                    break;
                }
            }
            if (!alreadyInCart)
            {
                _cartList.AddToCart(movieIn, currentUser, false);
                currentUser.UserCartTotal += movieIn.PurchasePrice;
                _context.SaveChanges();

                TempData["Result"] = movieIn.MovieTitle + " was successfully added to your cart.";
            }
            else
            {
                TempData["Failure"] = movieIn.MovieTitle + " is already in your cart";
            }
            return RedirectToAction("CustomerHomepage");
        }

        public IActionResult DisplayCart()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (currentUser != null)
            {

                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);
                ViewBag.Total = currentUser.UserCartTotal;
                if (TempData["Result"] != null)
                    ViewBag.Result = TempData["Result"];
                if (TempData["HasBalance"] != null)
                    ViewBag.HasBalance = TempData["HasBalance"];
                return View(userCart);
            }
            else
                return View("Login ");
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int cartId)
        {
            Cart foundCartItem = _cartList.GetCartItemById(cartId);
            _cartList.RemoveFromCart(foundCartItem);
            foundCartItem.CartOwner.UserCartTotal -= _cartList.getMoviePrice(foundCartItem.Movie, foundCartItem.IsRental);
            _context.SaveChanges();
            TempData["Result"] = foundCartItem.Movie.MovieTitle + " was successfully removed from your cart.";
            return RedirectToAction("DisplayCart");
        }

        public IActionResult DisplayCheckout()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser.AmountOwed != 0)
            {
                TempData["HasBalance"] = "You cannot checkout these items. You currently have an outstanding balance of $" + currentUser.AmountOwed + ".";
                return RedirectToAction("DisplayCart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionDetails inputDetails)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);
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

                Transaction newTransaction = _transactionList.CreateTransaction(cartItem.Movie, currentUser, cartItem.IsRental);
                _transactionDetailsList.AddTransactionDetails(inputDetails, newTransaction);

                if (cartItem.IsRental)
                {
                    _rentalList.AddRental(newTransaction);
                }
                else
                {
                    _purchaseList.AddPurchase(newTransaction);

                };
                cartItem.Movie.MovieInventory--;
            };

            _context.SaveChanges();
            return RedirectToAction("DisplayOrderConfirmation");
        }

        public IActionResult DisplayOrderConfirmation()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (currentUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);
                decimal cartTotal = 0;
                foreach (var cartItem in userCart)
                {
                    cartTotal += _cartList.getMoviePrice(cartItem.Movie, cartItem.IsRental);
                }
                currentUser.UserCartTotal = cartTotal;

                ViewBag.Total = currentUser.UserCartTotal.ToString();
                return View(userCart);
            }
            else
                return View("Login");
        }

        public IActionResult Orderconfirmed()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));

            if (currentUser != null)
            {
                IEnumerable<Cart> userCart = _cartList.GetCartItemsByUser(currentUser);
                foreach (var cartItem in userCart)
                {
                    _cartList.RemoveFromCart(cartItem);
                }
                currentUser.AmountPaid += currentUser.UserCartTotal;
                currentUser.UserCartTotal = 0;
                _context.SaveChanges();

                return RedirectToAction("CustomerHomepage");
            }
            return View("Index");
        }

        public IActionResult ReturnRental()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                IEnumerable<Rental> OutstandingUserRentals = _rentalList.GetOutstandingUserRentals(currentUser);
                foreach (var rental in OutstandingUserRentals)
                {
                    var rentalDueDate = DateTime.Parse(rental.DueDate);
                    if (rentalDueDate < DateTime.Today)
                    {
                        rental.IsLate = true;
                        rental.DaysLate = (int)(DateTime.Today.Subtract(rentalDueDate).TotalDays);
                    }
                }
                _context.SaveChanges();
                return View(OutstandingUserRentals);
            }
            else
                return View("Login");
        }

        [HttpGet]
        public IActionResult ReturnRentedMovie(int rentalId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            Rental toBeReturned = _rentalList.GetRentalById(rentalId);

            if (currentUser != null && toBeReturned != null)
            {
                if (!toBeReturned.IsLate)
                {
                    toBeReturned.Returned = true;
                    _context.SaveChanges();
                    ViewBag.Result = "Your return has been successfully processed";
                    return RedirectToAction("ReturnRental");
                }

                ViewBag.RentalId = toBeReturned.RentalId;
                return View("FeePayment");

            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult FeePayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeePayment(TransactionDetails inputdetails, int rentalId)
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            Rental toBeReturned = _rentalList.GetRentalById(rentalId);

            currentUser.AmountPaid += _rentalList.GetRentalById(rentalId).RentalFinalCost;
            currentUser.AmountOwed -= _rentalList.GetRentalById(rentalId).RentalFinalCost;

            toBeReturned.Returned = true;
            toBeReturned.RentalTransaction.TransactionMovie.MovieInventory++;

            inputdetails.MainTransaction = _rentalList.GetRentalById(rentalId).RentalTransaction;
            _context.SaveChanges();
            return RedirectToAction("ReturnRental");
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
            User currentUser = _customerList.GetUserByUsername(username);
            if (currentUser != null && currentUser.role != null)
            {

                if (currentUser.UserUserName.Equals(username) && currentUser.role.Equals("admin"))
                {
                    return RedirectToAction("AdminHomepage");
                }
                else if (currentUser.UserUserName.Equals(username) && currentUser.role != "admin")
                {
                    HttpContext.Session.SetString("Username", username);

                    IEnumerable<Rental> OutstandingUserRentals = _rentalList.GetOutstandingUserRentals(currentUser);
                    foreach (var rental in OutstandingUserRentals)
                    {
                        var rentalDueDate = DateTime.Parse(rental.DueDate);
                        if (rentalDueDate < DateTime.Today)
                        {
                            rental.IsLate = true;
                            rental.DaysLate = (int)(DateTime.Today.Subtract(rentalDueDate).TotalDays);
                            if (rental.IsLate && rental.DaysLate < 15)
                            {
                                rental.RentalFinalCost = (decimal)(rental.DaysLate * 2.00);
                                rental.RentalTransaction.Customer.AmountOwed += rental.RentalFinalCost;
                            }
                            else if (rental.IsLate && rental.DaysLate > 15)
                            {
                                rental.RentalFinalCost = (decimal)(rental.RentalTransaction.TransactionMovie.PurchasePrice + (decimal)(15 * 2.00));
                                rental.RentalTransaction.Customer.AmountOwed += rental.RentalFinalCost;
                            }
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("CustomerHomepage");
                }
                else
                    ViewBag.Result = "Something Went Wrong...";
            }
            else
                ViewBag.Result = "Invalid Username.";
            return View();
        }

        public IActionResult MovieSuggestions()
        {
            User currentUser = _customerList.GetUserByUsername(HttpContext.Session.GetString("Username"));
            if (currentUser != null)
            {
                IEnumerable<Transaction> userTransactions = _transactionList.GetUserTransactions(currentUser);

                List<string> userGenres = new List<string>();

                foreach (var transaction in userTransactions)
                {
                    userGenres.Add(_genreList.GetGenrebyObject(transaction.TransactionMovie.Genre));
                }

                List<string> distinctGenreNames = new List<string>();

                distinctGenreNames.AddRange(userGenres.Distinct());

                int[] genreCount = new int[distinctGenreNames.Count()];

                foreach (var genre in distinctGenreNames)
                {
                    foreach (var userGenre in userGenres)
                    {
                        if (userGenre == genre)
                            genreCount[distinctGenreNames.IndexOf(genre)]++;
                    }
                }

                int topGenreCount = 0;
                for (int i = 0; i < genreCount.Length; i++)
                {
                    if (topGenreCount < genreCount[i])
                        topGenreCount = i;
                }

                string mostBoughtGenre = distinctGenreNames.ElementAt(topGenreCount);

                string[] genres = mostBoughtGenre.Split('/');

                List<Movie> results = new List<Movie>();

                for (int i = 0; i < genres.Length; i++)
                {
                    results.AddRange(_movieList.SearchMovies(genres[i]));
                }

                results.OrderBy(m => m.MovieTitle);

                return View(results.AsEnumerable());
            }
            else
            {
                return View("Login");
            }
        }

        public IActionResult GenerateReports()
        {

            IEnumerable<SelectListItem> movies = _context.Movies.Select(m => new SelectListItem
            {
                Value = m.MovieNum.ToString(),
                Text = m.MovieTitle
            });

            ViewBag.movieItems = movies;

            IEnumerable<SelectListItem> genres = _context.Genre.Select(g => new SelectListItem
            {
                Value = g.GenreName,
                Text = g.GenreName
            });

            ViewBag.movieItems = movies;
            ViewBag.genreItems = genres;

            if (TempData["Failure"] != null)
                ViewBag.Failure = TempData["Failure"];
            return View();
        }

        [HttpPost]
        public IActionResult RevenueReport(string SearchType, string movieItems, string genreItems, string SearchRange, string StartDate, string TransactionType)
        {


            DateTime queryDate = DateTime.Parse(StartDate);
            DateTime endDate = new DateTime();
            switch (SearchRange)
            {
                case "Weekly":
                    endDate = queryDate.AddDays(7);
                    break;
                case "Monthly":
                    endDate = queryDate.AddMonths(1);
                    break;
                case "Yearly":
                    endDate = queryDate.AddYears(1);
                    break;
            }

            if (SearchType == "Genre")
            {
                Genre genreKey = _genreList.GetGenreByName(genreItems);
                List<Transaction> TransactionsByGenre = _transactionList.GetTransactionsByGenre(genreKey).ToList();
                Rental temp = new Rental();



                decimal rentalSum = 0;
                decimal purchaseSum = 0;
                decimal totalRevenue = 0;
                int returnedRentalCount = 0;
                int purchasecount = 0;
                int newRental = 0;
                int newPurchase = 0;

                foreach (var transaction in TransactionsByGenre)
                {
                    if (transaction.IsRental && DateTime.Parse(transaction.TransactionDate) > queryDate && DateTime.Parse(transaction.TransactionDate) < endDate)
                    {
                        temp = _rentalList.GetRentalByTransaction(transaction);
                        if (temp.Returned && temp.IsLate)
                        {
                            rentalSum += temp.RentalFinalCost;
                            returnedRentalCount++;
                        }
                        if(temp.Returned)
                        {
                            if (transaction.TransactionMovie.RentalPrice == (decimal)4.50)
                                newRental++;
                            rentalSum += transaction.TransactionMovie.RentalPrice;
                            returnedRentalCount++;
                        }
                    }
                    else
                    {
                        if (transaction.TransactionMovie.PurchasePrice == (decimal)30.00)
                            newPurchase++;
                        purchaseSum += transaction.TransactionMovie.PurchasePrice;
                        purchasecount++;
                    }
                }
                switch (TransactionType)
                {
                    case "All":
                        totalRevenue = purchaseSum + rentalSum;
                        ViewBag.TotalPurchases = purchasecount;
                        ViewBag.NewPurchases = newPurchase;
                        ViewBag.TotalRentals = returnedRentalCount;
                        ViewBag.NewRentals = newRental;
                        ViewBag.RentalSum = rentalSum;
                        ViewBag.Purchasesum = purchaseSum;
                        break;
                    case "Rentals":
                        totalRevenue = rentalSum;
                        ViewBag.NewRentals = newRental;
                        ViewBag.ReturnedRentals = returnedRentalCount;
                        ViewBag.RentalSum = rentalSum;
                        break;
                    case "Purchases":
                        totalRevenue = purchaseSum;
                        ViewBag.NewPurchases = newPurchase;
                        ViewBag.TotalPurchases = purchasecount;
                        ViewBag.Purchasesum = purchaseSum;
                        break;
                }
                ViewBag.TransactionType = TransactionType;
                ViewBag.TotalRevenue = totalRevenue;
                ViewBag.GenreName = genreItems;
                ViewBag.StartDate = queryDate.ToLongDateString();
                ViewBag.EndDate = endDate.ToLongDateString();

                return View("GenreRevenueReport");
            } else
            {
                Movie movieKey = _movieList.GetMovie(int.Parse(movieItems));
                List<Transaction> TransactionsByMovie = _transactionList.GetRevenueReportByTitle(movieKey).ToList();
                Rental temp = new Rental();

                decimal totalRevenue = 0;
                int totalPurchases = 0;
                int newPurchases = 0;
                int rentalsReturned = 0;
                int newRentals = 0;
                decimal rentalSum = 0;
                decimal purchaseSum = 0;

                foreach (var transaction in TransactionsByMovie)
                {
                    if (transaction.IsRental && DateTime.Parse(transaction.TransactionDate) > queryDate && DateTime.Parse(transaction.TransactionDate) < endDate)
                    {
                        temp = _rentalList.GetRentalByTransaction(transaction);
                        if (temp.Returned && temp.IsLate)
                        {
                            rentalSum += temp.RentalFinalCost;
                            rentalsReturned++;
                        }
                        if (temp.Returned)
                        {
                            if (transaction.TransactionMovie.RentalPrice == (decimal)4.50)
                                newRentals++;
                            rentalSum += transaction.TransactionMovie.RentalPrice;
                            rentalsReturned++;
                        }
                    }
                    else
                    {
                        if (transaction.TransactionMovie.PurchasePrice == (decimal)30.00)
                            newPurchases++;
                        purchaseSum += transaction.TransactionMovie.PurchasePrice;
                        totalPurchases++;
                    }

                }

                switch (TransactionType)
                {
                    case "Rentals":
                        totalRevenue = rentalSum;
                        ViewBag.TotalRentals = rentalsReturned;
                        ViewBag.NewRentals = newRentals;
                        ViewBag.RentalSum = rentalSum;
                        break;
                    case "Purchases":
                        totalRevenue = purchaseSum;
                        ViewBag.TotalPurchases = totalPurchases;
                        ViewBag.NewPurchases = newPurchases;
                        ViewBag.Purchasesum = purchaseSum;
                        break;
                    case "All":
                        totalRevenue = purchaseSum + rentalSum;
                        ViewBag.TotalPurchases = totalPurchases;
                        ViewBag.NewPurchases = newPurchases;
                        ViewBag.TotalRentals = rentalsReturned;
                        ViewBag.NewRentals = newRentals;
                        ViewBag.RentalSum = rentalSum;
                        ViewBag.Purchasesum = purchaseSum;
                        break;
                }
                ViewBag.TransactionType = TransactionType;
                ViewBag.MovieName = _movieList.GetMovie(int.Parse(movieItems)).MovieTitle;
                ViewBag.TotalRevenue = totalRevenue;
                ViewBag.StartDate = queryDate.ToLongDateString();
                ViewBag.EndDate = endDate.ToLongDateString();
                return View("MovieRevenueReport");
            }
        }
    }
}
