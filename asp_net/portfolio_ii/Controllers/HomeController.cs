using Microsoft.AspNetCore.Mvc;

namespace portfolio_ii.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet()][Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }//emd Index

        [HttpGet][Route("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }//end Projects
        [HttpGet][Route("contacts")]
        public IActionResult Contacts()
        {
            return View("Contacts");
        }//end contacts



    }//end Homecontroller
}//end namespace