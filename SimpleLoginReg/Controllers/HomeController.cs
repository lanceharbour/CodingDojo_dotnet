using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginReg.Models;

namespace SimpleLoginReg.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(IndexViewModel modelData)
        {
            RegUser submittedUser = modelData.NewUser;
            if(ModelState.IsValid)
            {
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
            LogUser submittedLogin = modelData.LoggedUser;
            if(ModelState.IsValid)
            {
                return RedirectToAction("success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("success")]
        public string Success()
        {
            return "SUCCESS";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
