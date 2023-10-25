using AnimeApp.Data;
using AnimeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(ApplicationDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _webHostEnvironment = web;
        }

        [Authorize]
        [Route("/admin/addanime")]
        public async Task<IActionResult> AddNewAnime(Anime anime)
        {

            if(ModelState.IsValid)
            {
                string folder = "anime/cover/";
                anime.CoverUrl = await UploadImage(folder, anime.Cover);

                _db.Animes.Add(anime);
                await _db.SaveChangesAsync();
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile cover)
        {
            folderPath += Guid.NewGuid().ToString() + '_' + cover.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await cover.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return '/' + folderPath;
        }

        [Authorize]
        public async Task<IActionResult> DeleteAnime(int animeId)
        {
            var anime = await _db.Animes.FirstOrDefaultAsync(a=>a.AnimeId== animeId);

            if (anime == null) 
            {
                return NotFound();  
            }

            return View(anime);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int animeId)
        {
            var anime = await _db.Animes.FirstOrDefaultAsync(a => a.AnimeId == animeId);

            if (anime == null)
            {
                return NotFound(); // Вернуть 404 Not Found, если аниме не найдено.
            }

            _db.Animes.Remove(anime);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Animes"); // Перенаправить на список аниме после удаления.
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int animeId)
        {
            var anime = await _db.Animes.FirstOrDefaultAsync(a => a.AnimeId == animeId);

            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Anime anime)
        {

            _db.Animes.Update(anime);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Animes"); // Перенаправить на список аниме после удаления.
        }
    }
}
