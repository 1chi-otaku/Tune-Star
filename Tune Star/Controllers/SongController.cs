using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tune_Star.BLL.DTO;
using Tune_Star.BLL.Interfaces;
using Tune_Star.BLL.Services;

namespace Tune_Star.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService songService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SongController(ISongService songServ, IWebHostEnvironment webHostEnvironment)
        {
            songService = songServ;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                SongDTO song = await songService.GetSong((int)id);
                return View(song);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public IActionResult Download(string filePath)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string fileFullPath = Path.Combine(webRootPath, filePath.TrimStart('/'));

            if (System.IO.File.Exists(fileFullPath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(fileFullPath);
                return File(fileBytes, "application/octet-stream", Path.GetFileName(fileFullPath));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
