using Microsoft.AspNetCore.Mvc;

namespace doj_survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }//end index

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string name, string location, string language, string comment)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            if(comment==null)
            {
                ViewBag.Comment = "empty comment.";
            }
            else
            {
                ViewBag.Comment = comment;
            }
            return View("Result");
        }//end Result
    }//end class Homecontroller

}//end namespace