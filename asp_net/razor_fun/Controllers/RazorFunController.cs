using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace razor_fun.Controllers
{
    public class RazorFunController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View("Index");
        }//end Index



    }//end arzorfuncontroller
}//end namespace RazorfunController