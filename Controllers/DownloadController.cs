using Microsoft.AspNetCore.Mvc;
using StartDialog.Services;

namespace StartDialog.Controllers
{
    public class DownloadController : Controller
    {
        private readonly ISongService _songService;

        public DownloadController(ISongService songService)
        {
            _songService = songService;
        }

        public async Task<IActionResult> Download(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song != null)
            {
                var fileStream = System.IO.File.OpenRead(song.FilePath);

                if (fileStream == null)
                {
                    return NotFound(); 
                }

                string mimeType = GetMimeType(song.FilePath);

                return File(fileStream, mimeType, $"{song.Title}{Path.GetExtension(song.FilePath)}");
            }

            return NotFound();
        }

        private string GetMimeType(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();
            switch (fileExtension)
            {
                case ".mp3":
                    return "audio/mpeg";
                case ".ogg":
                    return "audio/ogg";
                case ".wav":
                    return "audio/wav";
                default:
                    return "application/octet-stream";
            }
        }


    }

}
