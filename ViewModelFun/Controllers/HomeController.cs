using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Message message = new Message()
            {
                MessageContent = "Rantem necdum cumque una cap eamque sum vitiis. Hos heri ipsi novi est hoc aspi cum. Rom nul potuit non fueram animam. Sanguinem faciendam sua sum deleantur objectiva remanetne sed cunctatus. Opiniones examinare aggrediar naturales dat desumptas dem. Durent vacabo eo negans de paucos ex. Pudeat ha in attigi putare ad de."
            };
            return View(message);
        }

        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            int[] nums = new int[]
            {
                1,2,3,4
            };
            return View(nums);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult Users()
        {
            Person U1 = new Person()
            {
                FirstName = "Lance",
                LastName = "Tester"
            };

            Person U2 = new Person()
            {
                FirstName = "Erik",
                LastName = "Tester"
            };
            
            Person U3 = new Person()
            {
                FirstName = "Ethan",
                LastName = "Tester"
            };

            List<Person> Users = new List<Person>()
            {
                U1, U2, U3
            };

            return View(Users);
        }

        [HttpGet]
        [Route("user")]
        public IActionResult User()
        {
            Person U1 = new Person()
            {
                FirstName = "Lance",
                LastName = "Tester"
            };
            return View(U1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
