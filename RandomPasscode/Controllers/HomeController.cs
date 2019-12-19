using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {

            public string randStr(int size)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                string input = "ABDCEDFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Range(0, size).Select(x => input[rand.Next(0, input.Length)]).ToArray());
            }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("count") != null)
            {
                HttpContext.Session.SetInt32("count", ((int)HttpContext.Session.GetInt32("count") + 1));
                HttpContext.Session.SetString("random", randStr(14));
                ViewBag.Count = HttpContext.Session.GetInt32("count");
                ViewBag.Random = HttpContext.Session.GetString("random");
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("count", 1);
                HttpContext.Session.SetString("random", randStr(14));
                ViewBag.Count = HttpContext.Session.GetInt32("count");
                ViewBag.Random = HttpContext.Session.GetString("random");
                return View();
            }
        }

        [HttpPost]
        [Route("reset")]
        public IActionResult Reset()
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
