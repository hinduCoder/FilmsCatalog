using System.Collections.Generic;

namespace FilmsCatalog.Models
{
    public class MoviesList
    {
        public IEnumerable<string> Movies { get; set; }
        public int Page { get; set; }
        public bool HasNext { get; set; }
    }
}
