using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Data.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        [MaxLength(20)]
        public string MimeType { get; set; }
    }
}
