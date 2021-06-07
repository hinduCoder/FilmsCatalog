using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            return View(movie.Adapt<MovieViewModel>());
        }
    }
}
