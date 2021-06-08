using FilmsCatalog.Data;
using FilmsCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;
            var movies = await _dbContext.Movies
                .OrderBy(m => m.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize + 1)
                .Select(m => new MovieNameModel(m.Id, m.Name))
                .ToListAsync();
            return View(new MoviesListViewModel
            {
                Movies = movies.Take(pageSize),
                Page = page,
                HasNext = movies.Count > pageSize
            });
        }
    }
}
