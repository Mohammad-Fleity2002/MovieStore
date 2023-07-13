using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;

namespace Movies.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieGenre>MovieGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}