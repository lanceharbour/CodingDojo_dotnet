using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
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
        public IActionResult Register(User modelData)
        {
            if(ModelState.IsValid)
            {
                User newUser = modelData;
                if(dbContext.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);
                HttpContext.Session.SetInt32("id", userInDb.UserId);
                int id = userInDb.UserId;
                return Redirect($"/account/{id}");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Credential modelData)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == modelData.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email!  Try again.");
                    return View("login");
                }
                PasswordHasher<Credential> hasher = new PasswordHasher<Credential>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(modelData, userInDb.Password, modelData.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Password!  Try again.");
                    return View("login");
                }
                HttpContext.Session.SetInt32("id", userInDb.UserId);
                int id = userInDb.UserId;
                return Redirect($"/account/{id}");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("account/{id}")]
        public IActionResult Account()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                int id = (int)HttpContext.Session.GetInt32("id");

                User User = dbContext.Users
                .Where(u => u.UserId == id)
                .Include(u => u.Transactions).FirstOrDefault();

                double balance = 0;
                foreach (Transaction transaction in User.Transactions)
                {
                    balance += (double)transaction.Ammount;
                }

                AccountViewModel model = new AccountViewModel()
                {
                    VMUser = User,
                    Balance = balance
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Transaction(AccountViewModel modelData)
        {
            int id = modelData.VMTransaction.UserId;

            User User = dbContext.Users
            .Where(u => u.UserId == id)
            .Include(u => u.Transactions).FirstOrDefault();

            double balance = 0;
            foreach (Transaction transaction in User.Transactions)
            {
                balance += (double)transaction.Ammount;
            }

            AccountViewModel model = new AccountViewModel()
            {
                VMUser = User,
                Balance = balance
            };

            if ((int)modelData.Balance + (int)modelData.VMTransaction.Ammount < 0)
            {
                System.Console.WriteLine($"**********************Not enough money**********************");
                ModelState.AddModelError("Balance","Not enough money!");
                return View("Account", model);
            }
            else if (((int)modelData.VMTransaction.Ammount) == 0)
            {
            ModelState.AddModelError("Balance","Need to enter a value.");
            return View("Account", model);
            }
            else
            {
                if(ModelState.IsValid)
                {
                    Transaction newTrans = modelData.VMTransaction;
                    dbContext.Add(newTrans);
                    dbContext.SaveChanges();
                    return Redirect($"/account/{id}");
                }
                else
                {
                    return View("Account",model);
                }
            }
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
