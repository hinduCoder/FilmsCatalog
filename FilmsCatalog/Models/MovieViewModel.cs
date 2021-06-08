using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Models
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        [Display(Name = "Год выпуска")]
        [Range(1896, 2100, ErrorMessage = "Год выпуска не может быть меньше 1896 и слишком большим")]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Постер")]
        public IFormFile UploadedPoster { get; set; }

    }
}
