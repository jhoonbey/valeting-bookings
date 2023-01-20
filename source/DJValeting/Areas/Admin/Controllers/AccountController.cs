using DJValeting.Models.Entities;
using DJValeting.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DJValeting.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var checkResult = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (!checkResult)
                    {
                        ModelState.AddModelError("errorKey", "Invalid login or password");
                        return View(model);
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Dashboard");
                else
                    ModelState.AddModelError("errorKey", "Invalid login or password");
            }
            else
            {
                ModelState.AddModelError("errorKey", "Invalid login or password");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
