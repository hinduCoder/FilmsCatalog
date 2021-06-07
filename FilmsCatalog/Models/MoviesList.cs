using System.Collections.Generic;

namespace FilmsCatalog.Models
{
    public class MoviesList
    {
        public IEnumerable<MovieNameModel> Movies { get; set; }
        public int Page { get; set; }
        public bool HasNext { get; set; }
    }

    public record MovieNameModel(int Id, string Name);
}
