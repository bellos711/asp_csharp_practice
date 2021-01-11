using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace time_display.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet][Route("")]
        public IActionResult Index()
        {
            DateTime currentTime = DateTime.Now;
            currentTime.ToString("MMM dd, yyyy hh:mm tt");
            
            // ViewBag.currentTime = currentTime.ToString("MMM dd, yyyy hh:mm tt");
            return View("Index", currentTime);
        }//end index
    }//end HomeController
}//end namespace