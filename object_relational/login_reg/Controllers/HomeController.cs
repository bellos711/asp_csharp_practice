using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using login_reg.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace login_reg.Controllers
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
            WrapperModelLogRes WMod = new WrapperModelLogRes()
            {
                //passes the structure of the wrapper model it is just 2 objects fromf orm
            };
            return View("Index", WMod);
        }//end index

        [HttpPost("register")]
        public IActionResult Register(User FromForm)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("WE RAN THE REGISTER FUNCTION");
                System.Console.WriteLine($"This is our user {FromForm.FirstName}");
                if(_context.Users.Any(u => u.Email == FromForm.Email))
                {
                    System.Console.WriteLine("Email in use");
                    ModelState.AddModelError("Email", "Email already in use.");
                    return View("Index");
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

                    return RedirectToAction("Success");
                }
                
            }
            else
            {
                System.Console.WriteLine("DID NOT POST DATA");
                return Index();
            }
        }//end register


        [HttpPost("login")]
        public IActionResult Login(LoginUser FromForm)
        {
            System.Console.WriteLine("login-----------------------------------------------");
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
                        return Index();
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("Uuid", (int)Retrieved.UserId);
                    System.Console.WriteLine($"Email address logging in is {Retrieved}");
                    return RedirectToAction("Success");
                    }
                }
                else
                {
                    System.Console.WriteLine("No such user");
                    ModelState.AddModelError("LoginEmail", "No email address found");
                    return Index();
                }
            }
            else
            {
                System.Console.WriteLine("Invalid modelstate---------------");
                return Index();
            }
        }//end login

        [HttpGet("success")]
        public IActionResult Success()
        {

            int? Uuid = HttpContext.Session.GetInt32("Uuid");
            if(Uuid > 0)
            {
                ViewBag.YourUuid = Uuid; //the viewbag way
                User YourUser = _context.Users.FirstOrDefault(u => u.UserId == Uuid);
                return View("Success", YourUser); 
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }//end logout

    }//end homecontroller class
}//end namespace