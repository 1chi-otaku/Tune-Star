using Microsoft.AspNetCore.Mvc;

namespace Tune_Star.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
