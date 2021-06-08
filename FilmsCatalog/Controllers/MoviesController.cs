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
        private static readonly int PageSize = 10;
        private readonly ApplicationDbContext _dbContext;

        public MoviesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = await _dbContext.Movies
                .OrderBy(m => m.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize + 1)
                .Select(m => new MovieNameModel(m.Id, m.Name))
                .ToListAsync();
            return View(new MoviesListViewModel
            {
                Movies = movies.Take(PageSize),
                Page = page,
                HasNext = movies.Count > PageSize
            });
        }
    }
}
