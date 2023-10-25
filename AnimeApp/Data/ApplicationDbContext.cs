using AnimeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

namespace AnimeApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppUsers = Users;
        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<AnimeApplicationUser> AnimeApplicationUsers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AnimeImage> AnimeImages { get; set; }
    }
}
