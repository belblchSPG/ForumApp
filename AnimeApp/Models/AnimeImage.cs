using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AnimeApp.Models
{
    public class AnimeImage
    {
        [Key]
        public int RelId { get; set; }
        public Image Image { get; set; } = null!;
        public int AnimeId { get; set; }
        public Anime Anime { get; set; } = null!;

        public AnimeImage() { }

        public AnimeImage(Anime anime, Image image)
        {
            this.Image = image;
            this.Anime = anime;
        }
    }
}
