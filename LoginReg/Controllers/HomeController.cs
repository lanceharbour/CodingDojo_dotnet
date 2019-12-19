using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(IndexViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                User newUser = modelData.NewUser;
                if(dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("NewUser.Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == modelData.NewUser.Email);
                HttpContext.Session.SetInt32("id", userInDb.UserId);
                return RedirectToAction("success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(IndexViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == modelData.LoggedUser.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoggedUser.Email", "Invalid Email!  Try again.");
                    return View("Index");
                }
                PasswordHasher<IndexViewModel> hasher = new PasswordHasher<IndexViewModel>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(modelData, userInDb.Password, modelData.LoggedUser.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("LoggedUser.Password", "Invalid Password!  Try again.");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("id", userInDb.UserId);
                return RedirectToAction("success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                int id = (int)HttpContext.Session.GetInt32("id");
                return View("Success");
            }
            else
            {
                ModelState.AddModelError("LoggedUser.Email", "Please login with valid email account!");
                return View("Index");
            }
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
