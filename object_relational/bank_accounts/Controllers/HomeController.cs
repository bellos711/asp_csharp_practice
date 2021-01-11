using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using bank_accounts.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace bank_accounts.Controllers
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
            return View("Index");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("LoginPage");
        }

        [HttpPost("loginaction")]
        public IActionResult LoginLogic(LoginUser FromForm)
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
                        return Login();
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("Uuid", (int)Retrieved.UserId);
                        System.Console.WriteLine($"Email address logging in is {Retrieved.FirstName}");
                        return Redirect($"/account/{Retrieved.UserId}");
                    }
                }
                else
                {
                    System.Console.WriteLine("No such user");
                    ModelState.AddModelError("LoginEmail", "No email address found");
                    return Login();
                }
            }
            else
            {
                System.Console.WriteLine("Invalid modelstate---------------");
                return Login();
            }
        }

        [HttpPost("/register")]
        public IActionResult Register(User FromForm)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("model state for register is valid");
                if(_context.Users.Any(u => u.Email == FromForm.Email))
                {
                    System.Console.WriteLine("email in use");
                    ModelState.AddModelError("Email", "Email is in use");
                    return View("Index");
                }
                else
                {
                    System.Console.WriteLine("Everything is good to go and adding this user to db");
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    FromForm.Password = Hasher.HashPassword(FromForm, FromForm.Password);

                    _context.Add(FromForm); 
                    _context.SaveChanges(); //to save data to database
                    User Retrieved = _context.Users.FirstOrDefault(u => u.Email == FromForm.Email);
                    HttpContext.Session.SetInt32("Uuid", (int)Retrieved.UserId);

                    System.Console.WriteLine("-------creating default account----------");
                    Account DefaultAccount = new Account()
                    {
                        AccountName = "Standard Account",
                        AccountBalance = 100.00,
                        UserId = Retrieved.UserId
                    };//end default account

                    _context.Add(DefaultAccount);
                    _context.SaveChanges();
                    System.Console.WriteLine("Default account created");
                    
                    
                    return Redirect($"/account/{Retrieved.UserId}");
                }
                
            }
            else
            {
                System.Console.WriteLine("Model state for register invalid");
                return Index();
            }
        }

        [HttpGet("account/{UserId}")] //dont forget to putuserid 
        public IActionResult Account(int UserId)
        {
            int? Uuid = HttpContext.Session.GetInt32("Uuid");
            if(Uuid > 0)
            {
                ViewBag.YourUuid = Uuid; //the viewbag way
                User YourUser = _context.Users.Include(u => u.Accounts).Include(u => u.Transactions).FirstOrDefault(u => u.UserId == Uuid);
                return View("Account", YourUser); 
            }
            else
            {
                System.Console.WriteLine("Can't access account page, reg or login first");
                return RedirectToAction("Index");
            }
        }


        [HttpPost("depositwithdraw")]
        public IActionResult DepositWithdraw(double depositwithdrawFromForm)
        {
            int? Uuid = HttpContext.Session.GetInt32("Uuid");
            Account yourAccount = _context.Accounts.FirstOrDefault(a => a.UserId == Uuid);
            double yourBalance = (yourAccount.AccountBalance) + (depositwithdrawFromForm);
            if(yourBalance < 0)
            {
                System.Console.WriteLine("You can't withdraw that amount.");
                return Redirect($"/account/{Uuid}");
            }
            System.Console.WriteLine($"-------------------Account balance now = {yourBalance}");


            System.Console.WriteLine("-------processing transaction----------");
            Transaction newTransaction = new Transaction()
            {
                TransactionAmount = depositwithdrawFromForm,
                CreatedAt = DateTime.Now,
                UserId = (int)Uuid
            };//new transaction

            _context.Add(newTransaction);
            _context.SaveChanges();
            System.Console.WriteLine("New Transaction created");

            
            yourAccount.AccountBalance = yourBalance;
            yourAccount.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Redirect($"/account/{Uuid}");
        }


        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}

