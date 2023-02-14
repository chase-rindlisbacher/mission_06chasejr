using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
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
            return View();
        }
        /*This method will catch input from the MovieForm delivered as an instance of the MovieResponse class*/
        [HttpPost]
        public IActionResult MovieForm(MovieResponse movie)
        {
            /*save the form's data to the private movieContext variable to be passed to database*/
            _movieContext.Add(movie);
            _movieContext.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
