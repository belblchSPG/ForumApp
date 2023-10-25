using AnimeApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeApp.Models
{
    public class Image
    {
        static readonly string _path = "wwwroot/anime/";

        [Key]
        public int Id { get; set; }

        public string ImagePath { get; set; } = null!;

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int RelatedAnime { get; set; }

        public Image() { }

        public Image(Anime anime, IFormFile imageFile)
        {
            var title = anime.Title.ToLower();
            var year = anime.ReleaseYear;
            var id = anime.AnimeId;

            ImageFile = imageFile;
            ImagePath = _path + "{title}-{year}-id/" + imageFile.FileName;
        }
    }
}