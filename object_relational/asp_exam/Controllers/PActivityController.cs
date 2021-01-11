using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using asp_exam.Models;

namespace asp_exam.Controllers
{
    public class PActivityController : Controller
    {
        private MyContext _context;


        public PActivityController(MyContext context)
        {
            _context = context;
        }


        [HttpGet("home")]
        public IActionResult Home()
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                return Redirect("/");
            }


            int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
            User You = _context.Users.FirstOrDefault(u => u.UserId == Uuid);
            List<User> Creators = _context.Users.Include(u => u.PActivitiesCreated).ToList();
            
            DashboardWrapper DWmod = new DashboardWrapper()
            {
                ThisUser = You,
                AllActivities = _context.Activities
                    .Include(a => a.Creator)
                    .Include(a => a.UsersWhoJoined)
                    .OrderBy(a => a.DateNTime)
                    .ToList()
            };
            return View("Home", DWmod);
        }




        [HttpGet("new")]
        public IActionResult NewActivity()
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                return Redirect("/");
            }
            return View("NewActivity");
        }//end newactivity

        [HttpPost("new/create")]
        public IActionResult CreateActivity(PActivity FromForm)
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                System.Console.WriteLine("no user in session");
                return Redirect("/");
            }
            
            if(ModelState.IsValid)
            {
                if(FromForm.DateNTime <= DateTime.Now)
                {
                    System.Console.WriteLine("cant select past date");
                    ModelState.AddModelError("DateNTime", "You must enter a future date.");
                    return View("NewActivity");
                }
                
                FromForm.CreatorId = (int)HttpContext.Session.GetInt32("Uuid");
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }
            else
            {
                if(FromForm.DateNTime == null || FromForm.DateNTime < DateTime.Now)
                {
                    ModelState.AddModelError("DateNTime", "Select a valid date please...");
                    System.Console.WriteLine("acitivity did not post invalid model");
                
                    return View("NewActivity");
                }
                return NewActivity();
            }
        }




        [HttpGet("activity/{PActivityId}")]
        public IActionResult ActivityInfo(int PActivityId)
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                return Redirect("/");
            }
            int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
            User You = _context.Users.FirstOrDefault(u => u.UserId == Uuid);
            ViewBag.ThisUser = You;

            PActivity ThisActivity = _context.Activities
            .Include(a => a.Creator)
            .Include(a => a.UsersWhoJoined)
            .ThenInclude(u => u.UserJoined)
            .FirstOrDefault(a => a.PActivityId == PActivityId);
            return View("ActivityInfo", ThisActivity);
        }



        [HttpGet("home/{PActivityId}/join")]
        public IActionResult JoinActivity(int PActivityId)
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                return Redirect("/");
            }
            int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
            //check for security
            if(_context.UserJoinPActivities.Any(j => j.UserJoinedId == Uuid && j.PActivityJoinedId == PActivityId))
            {
                return RedirectToAction("Home");
            }
            System.Console.WriteLine("clicked activityJOIN");

            UserJoinPActivity ToAdd = new UserJoinPActivity()
            {
                UserJoinedId = Uuid,
                PActivityJoinedId = PActivityId
            };
            _context.Add(ToAdd);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }




        [HttpGet("home/{PActivityId}/leave")]
        public IActionResult LeaveActivity(int PActivityId)
        {
            if(HttpContext.Session.GetInt32("Uuid")==null)
            {
                return Redirect("/");
            }
            System.Console.WriteLine("clicked activityLEAVE");
            int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
            //check for security
            if(!_context.UserJoinPActivities.Any(j => j.UserJoinedId == Uuid && j.PActivityJoinedId == PActivityId))
            {
                return RedirectToAction("Home");
            }
            UserJoinPActivity ToRemove = _context.UserJoinPActivities.FirstOrDefault(j => j.UserJoinedId == Uuid && j.PActivityJoinedId == PActivityId);
            _context.Remove(ToRemove);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }





        [HttpGet("home/{PActivityId}/delete")]
            public IActionResult DeleteActivity(int PActivityId)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                System.Console.WriteLine("clicked activitydelete");
                PActivity ActivityToDelete = _context.Activities.FirstOrDefault(a => a.PActivityId == PActivityId);
                _context.Remove(ActivityToDelete);
                _context.SaveChanges();
                return RedirectToAction("Home");
            }



    }
}