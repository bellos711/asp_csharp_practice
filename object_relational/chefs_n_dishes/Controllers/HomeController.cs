using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using chefs_n_dishes.Models;

namespace chefs_n_dishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = _context.Chefs
                .Include(c => c.Dishes)
                .OrderBy(c => c.ChefFName)
                .ToList();
            

            // // Save today's date.
            // var today = DateTime.Today;
            // var chef1bday = AllChefs[0].ChefAge;

            // // Calculate the age.
            // var age = today.Year - chef1bday.Year;

            // // Go back to the year in which the person was born in case of a leap year
            // if (chef1bday.Date > today.AddYears(-age)) age--;
            // System.Console.WriteLine($"bday of chef1 is  {age}");

            return View("Index", AllChefs);
        }

        [HttpGet("dishes")]
        public IActionResult DishesPage()
        {
            List<Dish> AllDishes = _context.Dishes
                .Include(d => d.ChefObj)
                .OrderBy(d => d.Name)
                .ToList();
            return View("DishesPage", AllDishes);
        }


        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }


        [HttpPost("addchef")]
        public IActionResult AddChef(Chef FromForm)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("Add chef model state is valid. Adding chef");
                if(_context.Chefs.Any(c => (c.ChefFName == FromForm.ChefFName) && (c.ChefLName == FromForm.ChefLName) ))
                {
                    System.Console.WriteLine("Chef already with that same name fname and lname ");
                    ModelState.AddModelError("ChefFName", "There's a chef with that first and last name");
                    return View("NewChef");
                }
                else
                {
                    System.Console.WriteLine("Good to go. Adding this chef now");
                    _context.Add(FromForm);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                System.Console.WriteLine("Modelstate invalid, did not post data");
                return NewChef();
            }
        }//end addchef

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = _context.Chefs.Include(c => c.Dishes).OrderBy(c=>c.ChefFName).ToList();
            return View("NewDish");
        }//end newdish

        [HttpPost("dishes/adddish")]
        public IActionResult AddDish(Dish FromForm)
        {
            System.Console.WriteLine("Logic to add the dish");
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("valid modelstate adding dish to db");
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("DishesPage");
            }
            else
            {
                System.Console.WriteLine("Dish modelstate invalid");
                return NewDish();
            }
        }//end adddish

        

    }
}