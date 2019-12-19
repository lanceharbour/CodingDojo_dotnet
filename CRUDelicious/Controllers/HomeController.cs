using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(d => d.CreatedAt).ToList();

            return View(AllDishes);
        }

        [HttpGet("{dishID}")]
        public IActionResult ViewDish(int dishID)
        {
            Dish viewDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishID);
            return View(viewDish);
        }

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpGet("edit/{dishID}")]
        public IActionResult EditDish(int dishID)
        {
            Dish editDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishID);
            return View(editDish);
        }

        [HttpPost]
        public IActionResult UpdateDish(Dish updateDish)
        {
            if(ModelState.IsValid)
            {
            System.Console.WriteLine($"******************{updateDish.DishId}******************");
                dbContext.Dishes.Update(updateDish);
                
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpGet("delete/{dishID}")]
        public IActionResult DelDish(int dishID)
        {
            Dish delDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishID);
            dbContext.Dishes.Remove(delDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
