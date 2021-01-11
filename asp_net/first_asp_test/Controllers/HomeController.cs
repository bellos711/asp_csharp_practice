using Microsoft.AspNetCore.Mvc;

namespace first_asp_test.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }//end Index

        [HttpGet("name/{yourName}")]
        public string NameRouteWithParam(string yourName)
        {
            return $"your name is {yourName}";
        }
    }
}