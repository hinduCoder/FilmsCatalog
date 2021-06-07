using FilmsCatalog.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Data.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        public User CreatedBy { get; set; }
        public Image Poster { get; set; }
        [ForeignKey(nameof(Poster))]
        public int? PosterId { get; set; }

    }
}
