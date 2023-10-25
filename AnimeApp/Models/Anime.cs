using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeApp.Models
{
    public class Anime
    {
        [Key]
        public int AnimeId { get; set; }


        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Release Year")]
        public int ReleaseYear { get; set; } = 1901;
        public List<ApplicationUser> UsersWatched { get; } = new();

        [Required]
        [NotMapped]
        public IFormFile Cover { get; set; }
        public string CoverUrl { get; set; } = "";
        public Anime() { }
    }
}
