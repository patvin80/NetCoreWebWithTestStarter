using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplication.Controllers
{

    public class HomeController : Controller
    {
        private AppSettings _settings;

        public HomeController()
        {
        }
        public HomeController(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _settings.Title;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        [HttpGetAttribute("/EmpList")]
        public IActionResult JSonResultAPI()
        {
            return new JsonResult("{ 'name': 'Welcome Tester'}");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
