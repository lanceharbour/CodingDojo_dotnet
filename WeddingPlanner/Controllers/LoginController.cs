using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers
{
    public class LoginController : Controller
    {
        private MyContext dbContext;
        public LoginController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == modelData.LoginUser.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginUser.Email", "Invalid Email!  Try again.");
                    return View("Login");
                }
                PasswordHasher<LoginViewModel> hasher = new PasswordHasher<LoginViewModel>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(modelData, userInDb.Password, modelData.LoginUser.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginUser.Password", "Invalid Password!  Try again.");
                    return View("Login");
                }
                // adding UserId to session
                HttpContext.Session.SetInt32("user_id", userInDb.UserId);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(LoginViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                User newUser = modelData.NewUser;
                if(dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("NewUser.Email", "Email already in use!");
                    return View("Login");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                // retreiving new UserId to put user in session
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == modelData.NewUser.Email);
                HttpContext.Session.SetInt32("user_id", userInDb.UserId);
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
