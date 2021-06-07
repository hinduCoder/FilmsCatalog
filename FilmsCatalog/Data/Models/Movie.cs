using FilmsCatalog.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Desciprtion { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        public User CreatedBy { get; set; }
        public Image Poster { get; set; }

    }
}
