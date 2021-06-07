using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 10;
            var movies = _dbContext.Movies
                .OrderBy(m => m.Id)
                .Skip((page-1)* pageSize)
                .Take(pageSize+1).Select(m => m.Name)
                .ToList();
            return View(new MoviesList
            {
                Movies = movies.Take(pageSize),
                Page = page,
                HasNext = movies.Count > pageSize
            });
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
    }
}
