using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie_mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        /*Will call the Index.cshtml file*/
        public IActionResult Index()
        {
            return View();
        }
        /*Will call the MyPodcasts.cshtml file*/
        public IActionResult MyPodcasts()
        {
            return View();
        }
        /*Will call the MovieForm.cshtml file*/
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }
        /*This method will catch input from the MovieForm delivered as an instance of the MovieResponse class*/
        [HttpPost]
        public IActionResult MovieForm(MovieResponse movie)
        {
            // save the form's data to the private movieContext variable to be passed to database
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("MovieList");
            }
            else
            {
                BadRequest(ModelState);
                return View();
            }
        }
        public IActionResult MovieList()
        {
            var movies = _movieContext.Responses
                .Include(x => x.Category)
                //.OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
    }
}
