using FilmsCatalog.Data;
using FilmsCatalog.Data.Models;
using FilmsCatalog.Extensions;
using FilmsCatalog.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult New()
        {
            return View("Edit", new MovieViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            return View(movie.Adapt<MovieViewModel>());
        }

        public async Task<IActionResult> Save(MovieViewModel model)
        {
            var movie = new Movie { Id = model.Id ?? default };
            _dbContext.Attach(movie);
            movie = model.Adapt(movie);

            if (model.UploadedPoster is not null)
            {
                movie.Poster = new Image
                {
                    ImageData = await model.UploadedPoster.GetBytesAsync(),
                    MimeType = model.UploadedPoster.ContentType
                };
            }
            await _dbContext.SaveChangesAsync();
           
            return RedirectToAction(nameof(Details), new { id = movie.Id });
        }
    }
}
//TODO
//Валидация
//Пользователь, безопасность
//Рефакторинг
