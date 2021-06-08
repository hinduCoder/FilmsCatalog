namespace FilmsCatalog.Models
{
    public class MovieDetailsViewModel : MovieViewModel
    {
        public int? PosterId { get; set; }
        public bool AllowEditing { get; set; }
    }
}
