using FilmsCatalog.Data;
using FilmsCatalog.Data.Models;
using FilmsCatalog.Extensions;
using FilmsCatalog.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public MovieController(ApplicationDbContext dbContext, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            var movieModel = movie.Adapt<MovieDetailsViewModel>();

            var user = await _userManager.GetUserAsync(User);
            movieModel.AllowEditing = user?.Id == movie.CreatedById;

            return base.View(movieModel);
        }

        public IActionResult New()
        {
            return View("Edit", new MovieViewModel());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            
            var user = await _userManager.GetUserAsync(User);
            if (movie.CreatedById != user.Id)
                return Forbid();

            return View(movie.Adapt<MovieViewModel>());
        }

        public async Task<IActionResult> Save(MovieViewModel model)
        {
            if (model.UploadedPoster?.ContentType.StartsWith("image") == false)
                ModelState.AddModelError(nameof(model.UploadedPoster), "Только картинки, пожалуйста");
            if (!ModelState.IsValid)
                return View("Edit", model);
            var isNew = !model.Id.HasValue;
            var movie = isNew ? new Movie() : _dbContext.Find<Movie>(model.Id);
            movie = model.Adapt(movie);

            if (isNew)
            {
                movie.CreatedBy = await _userManager.GetUserAsync(User);
            }

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
