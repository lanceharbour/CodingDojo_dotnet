    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using DojoSurvey.Models;

    namespace DojoSurvey.Controllers
    {
        public class DojoSurveyController : Controller
        {
            [HttpGet]
            [Route("")]
            public ViewResult Index()
            {
                return View();
            }

            [HttpPost]
            [Route("results")]
            public IActionResult PostResults(Survey survey)
            {
                    return RedirectToAction("Results", new{Name=survey.Name,Location=survey.Location,Language=survey.Language,Comments=survey.Comments});
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
        }
    }