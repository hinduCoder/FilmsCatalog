using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models
{
    public class MovieViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Режиссёр")]
        public string Director { get; set; }
        [Display(Name = "Год выпуска")]
        [Range(1896, int.MaxValue)]
        public int? ReleaseYear { get; set; }
        public int? PosterId { get; set; }
        [FileExtensions(Extensions = "jpg")]
        public IFormFile UploadedPoster { get; set; }
    }
}
