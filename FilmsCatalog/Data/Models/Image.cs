using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
    }
}
