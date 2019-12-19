using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidation.Models;

namespace DojoSurveyValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("results")]
        public IActionResult PostResults(Survey survey)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Results", new{Name=survey.Name,Location=survey.Location,Language=survey.Language,Comments=survey.Comments});
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("results")]
        public IActionResult Results(string Name, string Location,
            string Language, string Comments)
        {
            Survey newSurvey = new Survey()
            {
                Name = Name,
                Location = Location,
                Language = Language,
                Comments = Comments
            };
                return View(newSurvey);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
