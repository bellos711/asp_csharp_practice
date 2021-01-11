    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using wedding_planner.Models;


    namespace wedding_planner.Controllers     //be sure to use your own project's namespace!
    {
        public class WeddingController : Controller   
        {
            private MyContext _context;


            public WeddingController(MyContext context)
            {
                _context = context;
            }


            //for each route this controller is to handle:
            [HttpGet("dashboard")]     //Http Method and the route
            public IActionResult Dashboard() //When in doubt, use IActionResult
            {
                int? Uuid = HttpContext.Session.GetInt32("Uuid");
                if(Uuid > 0)
                {
                    ViewBag.YourUuid = Uuid; //the viewbag way
                    User YourUser = _context.Users.FirstOrDefault(u => u.UserId == Uuid);
                    DashboardWrapper DWMod = new DashboardWrapper()
                    {
                        ThisUser = YourUser,
                        AllWeddings = _context.Weddings.Include(w => w.UsersWhoRSVPed).ToList()
                    };//end DWMod
                    return View("Dashboard",DWMod); //or whatever you want to return
                }
                else
                {
                    System.Console.WriteLine("Can't access account page, reg or login first");
                    return Redirect("/");
                }
                
            }

            [HttpGet("newwedding")]
            public IActionResult NewWedding()
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                return View("NewWedding");
                
            }

            [HttpPost("createwedding")]
            public IActionResult CreateWedding(Wedding FromForm)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                
                if(ModelState.IsValid)
                {
                    if(FromForm.Date <= DateTime.Now)
                    {
                        System.Console.WriteLine("cant select past date");
                        ModelState.AddModelError("Date", "You must enter a future date.");
                        return View("NewWedding");
                    }
                    
                    FromForm.CreatorId = (int)HttpContext.Session.GetInt32("Uuid");
                    _context.Add(FromForm);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    if(FromForm.Date == null || FromForm.Date < DateTime.Now)
                    {
                        ModelState.AddModelError("Date", "Select a valid date please...");
                        System.Console.WriteLine("Wedding did not post invalid model");
                    
                        return View("NewWedding");
                    }
                    return NewWedding();
                }
                

            }

            [HttpGet("weddinginfo/{WeddingId}")]
            public IActionResult WeddingInfo(int WeddingId)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                Wedding ThisWedding = _context.Weddings
                    .Include(w => w.UsersWhoRSVPed)
                    .ThenInclude(u => u.UserRSVPed)
                    .FirstOrDefault(w => w.WeddingId == WeddingId);
                return View("WeddingInfo", ThisWedding);
            }

            [HttpGet("dashboard/{WeddingId}/rsvp")]
            public IActionResult RSVP(int WeddingId)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
                //check for security
                if(_context.UserWeddingRSVPs.Any(r => r.UserRSVPedId == Uuid && r.WeddingRSVPedId == WeddingId))
                {
                    return RedirectToAction("Dashboard");
                }


                UserWeddingRSVP ToAdd = new UserWeddingRSVP()
                {
                    UserRSVPedId = Uuid,
                    WeddingRSVPedId = WeddingId
                };
                _context.Add(ToAdd);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }


            [HttpGet("dashboard/{WeddingId}/unrsvp")]
            public IActionResult UnRSVP(int WeddingId)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                int Uuid = (int)HttpContext.Session.GetInt32("Uuid");
                //check for security
                if(!_context.UserWeddingRSVPs.Any(r => r.UserRSVPedId == Uuid && r.WeddingRSVPedId == WeddingId))
                {
                    return RedirectToAction("Dashboard");
                }
                UserWeddingRSVP ToRemove = _context.UserWeddingRSVPs.FirstOrDefault(r => r.UserRSVPedId == Uuid && r.WeddingRSVPedId == WeddingId);
                _context.Remove(ToRemove);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            [HttpGet("dashboard/{WeddingId}/delete")]
            public IActionResult DeleteWedding(int WeddingId)
            {
                if(HttpContext.Session.GetInt32("Uuid")==null)
                {
                    return Redirect("/");
                }
                Wedding WeddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId);
                _context.Remove(WeddingToDelete);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            
        }
    }
