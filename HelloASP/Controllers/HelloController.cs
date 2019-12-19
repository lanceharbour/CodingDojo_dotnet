using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace HelloASP.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("info")]
        public ViewResult Info()
        {
            return View("Info");
        }
        [HttpGet("elsewhere")]
        public ViewResult Elsewhere()
        {
            return View("Index");
        }
    }
}