using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AnimeApp.Models
{
    public class AnimeApplicationUser
    {
        [Key]
        public int RelId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public AnimeApplicationUser() { }

        public AnimeApplicationUser(Anime anime, ApplicationUser user) 
        {
            this.ApplicationUser = user;
            this.Anime = anime;
        }
    }
}
