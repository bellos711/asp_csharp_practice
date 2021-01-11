using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }//end index

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("Success");
        }//end Success

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User fromForm)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return Index();
            }
        }//end register


    }//end homecontroller
}//end namespace