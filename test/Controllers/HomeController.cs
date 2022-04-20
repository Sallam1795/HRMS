using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test.Data;
using test.Data.ViewModels;
using test.Models;

namespace test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController(){}

        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Login() => View(new LoginVM());

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM loginVM)
        //{
        //    if (!ModelState.IsValid) return View(loginVM);

        //    var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
        //    if (user != null)
        //    {
        //        var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
        //        if (passwordCheck)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        TempData["Error"] = "Wrong User. Please, try again!";
        //        return View(loginVM);
        //    }

        //    TempData["Error"] = "Wrong User. Please, try again!";
        //    return View(loginVM);
        //}



    }
}
