using Microsoft.AspNetCore.Mvc;
using Tune_Star.BLL.Interfaces;

namespace Tune_Star.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService songService;
        private readonly IGenreService genreService;

        public SongController(ISongService songServ, IGenreService genreServ)
        {
            songService = songServ;
            genreService = genreServ;
        }

        public async Task<IActionResult> Index()
        {
            return View(await songService.GetSongs());
        }
    }
}
