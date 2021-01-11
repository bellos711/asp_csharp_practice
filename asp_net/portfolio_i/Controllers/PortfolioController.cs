using Microsoft.AspNetCore.Mvc;


namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "This is my index";
        }//end index

        [HttpGet]
        [Route("projects")]
        public string Projects()
        {
            return "These are my projects";
        }//end index

        [HttpGet]
        [Route("contact")]
        public string Contact()
        {
            return "This is my contact";
        }//end index

    }   //end class portfoliocontroller 
}