using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartDialog.Data;
using StartDialog.Models;
using StartDialog.Services;

namespace StartDialog.Controllers
{
    public class AdminSongController : Controller
    {
        private readonly SongDbContext _context;
        private readonly ISongService _songService;
        public AdminSongController(SongDbContext context, ISongService songService)
        {
            _context = context;
            _songService = songService;
        }

        public async Task<IActionResult> Index()
        {
            var songs = await _context.Songs.ToListAsync();
            return View(songs);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(SongViewModel model)
        {
            if (ModelState.IsValid)
            {
                var song = new Song
                {
                    Title = model.Title,
                    Artist = model.Artist,
                };

                var musicFolder = @"D:\Other Programs\games\StartDialog\wwwroot\music";

                if (model.File != null && model.File.Length > 0)
                {
                    var fileName = Path.GetFileName(model.File.FileName);
                    var filePath = Path.Combine(musicFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }

                    song.FilePath = filePath;
                }

                await _songService.AddSongAsync(song);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song != null)
            {
                await _songService.DeleteSongAsync(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

    }
}


