using MovieRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRent.Controllers
{
    public class MovieController : Controller
    {
        public ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult Create()
        {
            IEnumerable<string> genres = new List<string> {"Action", "Horror", "Thriller", "Comedy", "Romance", "Sci-Fi"};
            ViewData["genres"] = genres;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                if (ModelState.IsValid) {
                    if (movie == null)
                    {
                        return View("Error");
                    } else
                        _context.Movies.Add(movie);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Movie");
                } else
                    return View(movie);
            }
            catch {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            IEnumerable<string> genres = new List<string> { "Action", "Horror", "Thriller", "Comedy", "Romance", "Sci-Fi" };
            ViewData["genres"] = genres;

            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                if (ModelState.IsValid && movie != null)
                {
                    Movie movieToBeUpdated = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);

                    movieToBeUpdated.Title = movie.Title;
                    movieToBeUpdated.Genre = movie.Genre;
                    movieToBeUpdated.ReleaseDate = movie.ReleaseDate;
                    movieToBeUpdated.DateAdded = movie.DateAdded;
                    movieToBeUpdated.NumberInStock = movie.NumberInStock;

                    _context.SaveChanges();
                    return RedirectToAction("Index", "Movie");
                }
                else
                    return HttpNotFound("This movie doesnt't exist. Id: " + movie.Id);
            }
            catch {
                return View(movie);
            }
            
        }


    }
}