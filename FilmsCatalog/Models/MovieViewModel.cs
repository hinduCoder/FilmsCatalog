namespace FilmsCatalog.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public int PosterId { get; set; }

    }
}
