using FilmsCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            var image = await _dbContext.Images.FindAsync(id);
            return File(image.ImageData, image.MimeType);
        }
    }
}
