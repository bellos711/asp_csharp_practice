using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using doj_survey_model.Models;

namespace doj_survey_model.Controllers
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
        [Route("registering")]
        public IActionResult Registering(Student fromForm)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("RegisterStudent", fromForm);
            }
            else
            {
                return Index();
            }
        }//end registering


        [HttpGet]
        [Route("RegisterStudent")]
        public IActionResult RegisterStudent(Student fromForm)
        {
            
            // System.Console.WriteLine(fromForm.name);
            // System.Console.WriteLine(fromForm.location);
            // System.Console.WriteLine(fromForm.language);
            // System.Console.WriteLine(fromForm.comment);
            Student myStudent;
            myStudent = fromForm;
            System.Console.WriteLine("------this is accessing that model-----");
            // System.Console.WriteLine(myStudent.name);
            // System.Console.WriteLine(myStudent.location);
            // System.Console.WriteLine(myStudent.language);
            // System.Console.WriteLine(myStudent.comment);
            

            return View("RegisterStudent", myStudent);
            
        }
    }//end homecontroller
}//end namespace