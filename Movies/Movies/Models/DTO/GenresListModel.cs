using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Models.Domain;

namespace Movies.Models.DTO
{
    public class GenresListModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenres { get; set; } 
        public string SearchString { get; set;}
    }
}
