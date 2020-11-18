using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
                           IGenreRepository genre
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

        }

        public IActionResult Index()
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
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerList()
        {
            return View(_customerList.GetAllCustomers().AsEnumerable());
        }

        public IActionResult AdminHomepage()
        {
            return View(_movieList.GetAllMovies());
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
                movieIn.Director = _directorList.AddDirector(DirectorFName,DirectorLName);

            _movieList.Add(movieIn);

            return RedirectToAction("AdminHomepage");
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
        public IActionResult Login(string customerIn, string password)
        {
            User foundUser = _customerList.GetUserByUsername(customerIn);
            if (foundUser != null)
            {

                if (foundUser.Equals(customerIn))
                {
                    return View("Index");
                }
                else
                    ViewBag.Result = "Something Went Wrong...";
            }
            else
                ViewBag.Result = "Invalid Username.";
            return View("Index");
        }
    }
}
