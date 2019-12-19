using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        private int SessionUser
        {
            get 
            {
                int sessionuser = (int)HttpContext.Session.GetInt32("user_id");
                return sessionuser;
            }
        }

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("user_id") != null)
            {
                List<Wedding> AllWeddings = dbContext.Weddings
                .Include(wedding => wedding.Guests)
                .ToList();

                WeddingViewModel model = new WeddingViewModel()
                {
                    Weddings = AllWeddings,
                    User = dbContext.Users.FirstOrDefault(u => u.UserId == SessionUser)
                };
                return View(model);
            }
            return RedirectToAction("Login","Login");
        }

        [HttpGet]
        public IActionResult NewWedding()
        {
            if (HttpContext.Session.GetInt32("user_id") != null)
            {
                return View();
            }
            return RedirectToAction("Login","Login");
        }

        [HttpPost]
        public IActionResult AddWedding(Wedding modelData)
        {
            if (HttpContext.Session.GetInt32("user_id") != null)
            {
                if(ModelState.IsValid)
                {
                    if(DateTime.Now > modelData.WeddingDate)
                    {
                        ModelState.AddModelError("WeddingDate", "Please enter a future date for wedding.");
                        return View("NewWedding");
                    }

                    Wedding newWedding = modelData;
                    newWedding.UserId = SessionUser;
                    dbContext.Add(newWedding);
                    dbContext.SaveChanges();
                    return View("Dashboard", "Home");
                }
                return View("NewWedding");
            }
            return RedirectToAction("Login","Login");
        }

        [HttpGet("/wedding/{weddingID}")]
        public IActionResult ViewWedding(int weddingID)
        {
            Wedding viewWedding = dbContext.Weddings.Where(w => w.WeddingId == weddingID)
            .Include(g => g.Guests)
            .ThenInclude(c => c.User).FirstOrDefault();
            
            return View(viewWedding);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
