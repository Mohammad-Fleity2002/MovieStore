namespace Movies.Models.Domain
{
    public class MovieGenre
    {  //movie can have many gender
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
    }
}
