using FilmsCatalog.Data;
using FilmsCatalog.Data.Models;
using FilmsCatalog.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            var movie = model.Adapt<Movie>();

            if (model.UploadedPoster is not null)
            {
                using var stream = model.UploadedPoster.OpenReadStream();
                var buffer = new byte[model.UploadedPoster.Length];
                await stream.ReadAsync(buffer);
                movie.Poster = new Image
                {
                    ImageData = buffer,
                    MimeType = model.UploadedPoster.ContentType
                };
            }
            if (model.Id.HasValue)
            {
                _dbContext.Update(movie);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            _dbContext.Add(movie);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
//TODO
//Разобраться с трекингов, загрузкой изображения, потерей, вот это всё
//Валидация
//Пользователь, безопасность
//Рефакторинг
