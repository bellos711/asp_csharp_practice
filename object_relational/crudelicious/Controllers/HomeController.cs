using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using crudelicious.Models;
//newstuff
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        //new stuff
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }//end constructor Homecontroller context


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //get all dishes
            List<Dish> AllDishes = _context.Dishes.ToList();
            // IEnumerable<Dish> AllDishes = _context.Dishes;
            

            // //get ONE dish from database with id of 2
            // Dish SecondDish = _context.Dishes.FirstOrDefault(d => d.DishId == 2);

            // //get all dishes that have tastiness of 3 or lower
            // List<Dish> TastinessOf3OrLower = _context.Dishes
            //     .Where(d => d.Tastiness <= 3)
            //     .ToList();

            

            return View("Index", AllDishes);
        }//end index

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View("NewDish");
        }//end newdish

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDish(Dish fromForm)
        {
            // Dish PizzaPie = new Dish()
            // {
            //     Name = "PizzaPie",
            //     Chef = "Mareeoh",
            //     Tastiness = 3,
            //     Calories = 900,
            //     Description = "When the moon hits your eye like a big pizza pie, that's amore"
            // };



            // _context.Add(fromForm); //OR _context.Dishes.Add("PizzaPie");
            // _context.SaveChanges(); //to save data to database
            System.Console.WriteLine("YOU ARE IN HTTPPOST CREATE DISH");
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("SUCCESS");
                _context.Add(fromForm); //OR _context.Dishes.Add("PizzaPie");
                _context.SaveChanges(); //to save data to database
                return RedirectToAction("Index");
            }
            else
            {
                System.Console.WriteLine("FAILED TO POST");
                // return RedirectToAction("NewDish"); //CANNOT DO THIS
                return NewDish();
            }
            
        }//end createdshi

        [HttpGet("edit/{DishId}")]
        public IActionResult EditDish(int DishId)
        {
            Dish Retrieved = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            return View("EditDish", Retrieved);
        }//end EditDish


        [HttpPost("update/{DishId}")]
        public IActionResult UpdateDish(int DishId, Dish fromForm)
        {
            //which dish to update? grab it from db
            //this should be inside modelstate isvalid n stuff
            bool Retrieved = _context.Dishes.Any(d => d.DishId == DishId);
            if(Retrieved == false)
            {
                return RedirectToAction("Index");
            }

            System.Console.WriteLine("YOU ARE IN HTTPPOST EDIT DISH");
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("SUCCESS EDIT");
                fromForm.DishId = DishId; //dishid from the url
                _context.Update(fromForm); //applies that update to all but we dont  want created at as modified
                _context.Entry(fromForm).Property("CreatedAt").IsModified = false;
                _context.SaveChanges();
                // Retrieved.Name = fromForm.Name;
                // Retrieved.Chef = fromForm.Chef;
                // Retrieved.Tastiness = fromForm.Tastiness;
                // Retrieved.Calories = fromForm.Calories;
                // Retrieved.Description = fromForm.Description;
                // Retrieved.UpdatedAt = fromForm.UpdatedAt;

                // _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                System.Console.WriteLine("FAILED TO EDIT");
                // return RedirectToAction("NewDish"); //CANNOT DO THIS
                return EditDish(DishId);
            }

            

        }//end  updatedish

        [HttpGet("delete/{DishId}")]
        public IActionResult DeleteDish(int DishId)
        {
            //logic to determine if we should delete
            Dish ToDelete = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if(ToDelete == null)
            {
                return RedirectToAction("Index");
            }

            _context.Remove(ToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }//end deletedish

        [HttpGet("{DishId}")]
        public IActionResult Display(int DishId)
        {
            Dish Retrieved = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            if(Retrieved == null)
            {
                return RedirectToAction("Index");
            }
            return View("Display", Retrieved);
        }

    }//end class
}//end namespace