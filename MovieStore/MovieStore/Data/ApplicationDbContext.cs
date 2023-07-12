using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStore.Models;

namespace MovieStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieStore.Models.Categories> Categories { get; set; } = default!;
        public DbSet<MovieStore.Models.Movies> Movies { get; set; } = default!;
        public DbSet<MovieStore.Models.User_Roles> User_Roles { get; set; } = default!;
        public DbSet<MovieStore.Models.Users> Users { get; set; } = default!;
    }
}