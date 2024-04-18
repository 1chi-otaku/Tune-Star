using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Tune_Star.BLL.DTO;
using Tune_Star.BLL.Interfaces;
using Tune_Star.BLL.Services;
using Tune_Star.DAL.Entities;
using Tune_Star.Models;

namespace Tune_Star.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userServ)
        {
            userService = userServ;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult RegistrationNotification()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterModel reg)
        {

            if (reg.Name == reg.Login) ModelState.AddModelError("", "Login and Name can NOT be the same!");


            if (ModelState.IsValid)
            {
                int status = 0;
                if (reg.Login == "admin") status = 3;
                var userDTO = new UserDTO
                {
                    Login = reg.Login,
                    Password = reg.Password,
                    Status = status,
                };

                await userService.CreateUser(userDTO);
                return RedirectToAction("RegistrationNotification", "Users");
            }

            return View(reg);
        }

    }
}
