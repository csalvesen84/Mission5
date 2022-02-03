using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission4.Models;
using System.Linq;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context { get; set; }

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Movies ()
        {
            var movieList = _context.Movies.Include(x => x.Category)
                .ToList();
            return View(movieList);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie submission)
        {
            ViewBag.Categories = _context.Categories.ToList();

            //Won't move on unless you have all the required fields (so that it can display the required tag infomation)
            if (ModelState.IsValid)
            {
                _context.Add(submission);
                _context.SaveChanges();
                return View("Confirmation", submission);
            }
            else{
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var movie = _context.Movies.Single(x => x.MovieId == movieid);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit (Movie mov)
        {
            _context.Movies.Update(mov);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = _context.Movies.Single(x => x.MovieId == movieid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie mov)
        {
            _context.Movies.Remove(mov);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
