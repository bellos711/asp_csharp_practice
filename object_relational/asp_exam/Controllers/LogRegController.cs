using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using asp_exam.Models;


namespace asp_exam.Controllers     //be sure to use your own project's namespace!
{
    public class LogRegController : Controller   
    {
        private MyContext _context;


        public LogRegController(MyContext context)
        {
            _context = context;
        }


        //for each route this controller is to handle:
        [HttpGet("")]     //Http Method and the route
        public IActionResult LogRegPage() //When in doubt, use IActionResult
        {
            return View("LogRegPage"); //or whatever you want to return
        }




        [HttpPost("register")]
        public IActionResult Register(User FromForm)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == FromForm.Email))
            {
                System.Console.WriteLine("Email in use");
                ModelState.AddModelError("Email", "Email already in use.");
                return LogRegPage();
            }
            else
            {
                System.Console.WriteLine("YOU ARE GOOD TO GO!");
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);

                _context.Add(FromForm); 
                _context.SaveChanges(); //to save data to database
                User Retrieved = _context.Users.FirstOrDefault(u => u.Email == FromForm.Email);
                HttpContext.Session.SetInt32("Uuid", (int)Retrieved.UserId);

                return Redirect("Home");
            }
                
            }
            else
            {
                System.Console.WriteLine("invalid modelstate");
                return LogRegPage();
            }

        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser FromForm)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("State is valid in login");
                bool UserExist = _context.Users.Any(u => u.Email == FromForm.LoginEmail);
                if(UserExist)
                {
                    System.Console.WriteLine("There is a user");
                    User Retrieved = _context.Users.FirstOrDefault(u => u.Email == FromForm.LoginEmail);
                    
                    //initialize the hasher object
                    var hashSlingingSlasher = new PasswordHasher<LoginUser>();

                    //verify provided password against hash stored in db
                    var result = hashSlingingSlasher.VerifyHashedPassword(FromForm, Retrieved.Password, FromForm.LoginPassword);

                    //result can be compared to 0 for failure
                    if(result == 0)
                    {
                        //failure handling
                        System.Console.WriteLine("password was wrong");
                        ModelState.AddModelError("LoginPassword", "Password incorrect");
                        return LogRegPage();
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("Uuid", (int)Retrieved.UserId);
                        System.Console.WriteLine($"Email address logging in is {Retrieved}");
                        return Redirect("Home");
                    }
                }
                else
                {
                    System.Console.WriteLine("No such user");
                    ModelState.AddModelError("LoginEmail", "No email address found");
                    return LogRegPage();
                }
            }
            else
            {
                System.Console.WriteLine("invalid modelstate in login");
                return LogRegPage();
            }

        }//end login function






        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogRegPage");
        }

        
    }
}
