using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
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
            DateTime now = DateTime.Today;
            List<Chef> AllChefs = dbContext.Chefs
            .Include(chef => chef.CreatedDishes)
            .ToList();

            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddChef(Chef modelData)
        {
            if(ModelState.IsValid)
            {
                Chef newChef = modelData;
                if (DateTime.Now < newChef.DateOfBirth)
                {
                    ModelState.AddModelError("DateOfBirth","Please enter a valid DOB.");
                    return View("NewChef");
                }
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            CnDViewModel NewDishVM = new CnDViewModel()
            {
                ChefList = dbContext.Chefs.ToList()
            };
            return View(NewDishVM);
        }

        [HttpPost]
        public IActionResult AddDish(CnDViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                Dish newDish = modelData.VMDish;
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                CnDViewModel NewDishVM = new CnDViewModel()
                {
                    ChefList = dbContext.Chefs.ToList()
                };
                return View("NewDish", NewDishVM);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
