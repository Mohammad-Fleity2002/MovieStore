namespace Movies.Repositories.Abstract
{
    public interface IFileService
    {//Concerned with the images of movies
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);

    }
}
