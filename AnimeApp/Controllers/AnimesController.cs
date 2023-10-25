using AnimeApp.Data;
using AnimeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeApp.Controllers
{
    public class AnimesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        public AnimesController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index(string searchString)
        {

            var animes = from a in _db.Animes
                         select a;

            if(!String.IsNullOrEmpty(searchString))
            {
                animes = animes.Where(b => b.Title.ToLower().Contains(searchString.ToLower()));
            }

            ViewData["CurrentSearchString"] = searchString;

            return View(animes);
        }

        [Route("animes/{animeId}")]    
        public async Task<IActionResult> Anime(int animeId)
        {
            var anime = await _db.Animes.FirstOrDefaultAsync(a=>a.AnimeId == animeId);

            if(anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        [Authorize]
        [Route("/animes/add_anime_to_user/{animeId}")]
        public async Task<JsonResult> AddAnimeToUser(int animeId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var anime = _db.Animes.First(a => a.AnimeId == animeId);

                AnimeApplicationUser relationship = new AnimeApplicationUser(anime, user);

                if (user == null || anime == null)
                {
                    return new JsonResult(new { result = false });
                }

                await _db.AnimeApplicationUsers.AddAsync(relationship);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return new JsonResult(new { result = true });
        }

        [Authorize]
        [Route("/animes/remove_anime_from_user/{animeId}")]
        public async Task<JsonResult> RemoveAnimeFromUser(int animeId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _db.AnimeApplicationUsers.FirstOrDefaultAsync(r => (r.AnimeId == animeId && r.ApplicationUser.Id == user.Id));

                _db.AnimeApplicationUsers.Remove(result);
                await _db.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
            return new JsonResult(new { result = true });
        }

        [Authorize]
        [Route("/animes/check_user_anime/{animeId}")]
        public async Task<JsonResult> CheckUserAnime(int animeId) 
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _db.AnimeApplicationUsers.FirstOrDefaultAsync(r => (r.AnimeId == animeId && r.ApplicationUser.Id == user.Id));

            if (result == null)
            {
                return new JsonResult(new { watched = false });
            }

            return new JsonResult(new { watched = true }); ;
        }
    }
}
