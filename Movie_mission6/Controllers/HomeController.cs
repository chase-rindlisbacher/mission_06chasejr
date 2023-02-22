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
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                BadRequest(ModelState);
                return View(movie);
            }
        }
        /*Will call a view that displays all the movies in your database.*/
        public IActionResult MovieList()
        {
            var movies = _movieContext.Responses
                .Include(x => x.Category)
                //.OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
        /*Edit get method to pull up movie form that will autofill with your selected movies current values.*/
        [HttpGet]
        public IActionResult Edit(int MovieID)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movie = _movieContext.Responses.Single(x => x.MovieID == MovieID);
            return View("Edit", movie);
        }
        /*Edit post method will be called when you submit your updates. Will validate submission and save to database then return you to the MovieList action.*/
        [HttpPost]
        public IActionResult Edit(MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else // If Invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                BadRequest(ModelState);
                return View(movie);
            }
        }
        /*Delete Get method for when the delete button is pushed on the MovieList view*/
        [HttpGet]
        public IActionResult Delete(int MovieId)
        {
            var movie = _movieContext.Responses.Single(x => x.MovieID == MovieId);
            return View(movie);
        }
        /*Delete Post method for when the delete form is submitted*/
        [HttpPost]
        public IActionResult Delete(MovieResponse movie)
        {
            _movieContext.Responses.Remove(movie);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
